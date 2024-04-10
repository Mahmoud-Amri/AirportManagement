﻿namespace AM.Core.Domain;
using System.ComponentModel.DataAnnotations;

public class Passenger
{
    private int age;
    [DataType(DataType.Date)]
    [Display(Name = "Date of birth ")]
    public DateTime BirthDate { get; set; }

    public int Age
    {
        get
        {
            if (DateTime.Now < BirthDate.AddYears(age)) age--;

            return age;
        }
    }

    [Key]
    [StringLength(7)] // stringlength temchi cote front w fama MaxMinLenghth temchi cote base
    public string PasseportNumber { get; set; }

    [EmailAddress]
    public string EmailAdress { get; set; }


    [MinLengthAttribute(3) ]
    [MaxLengthAttribute(25)] 
    // public string FirstName { get; set; }
    // public string LastName { get; set; }
    public FullName MyFullName { get; set; }

    [RegularExpression(@"^[0-9]{8}$",ErrorMessage ="invalid phone number")]

    public string TelNumber { get; set; }

    //public IList<Flight> Flights { get; set; }
    public IList<Reservation> Reservations { get; set; }
    public override string ToString()
    {
        return "BirthDate:" + BirthDate
                            + "PasseportNumber:" + PasseportNumber
                            + "EmailAdress:" + EmailAdress
                            + "FirstName:" + MyFullName.FirstName
                            + "LastName:" + MyFullName.LastName
                            + "TelNumber:" + TelNumber;
    }

    public bool CheckProfile(string FirstName, string LastName)
    {
        return this.MyFullName.FirstName == FirstName && this.MyFullName.LastName == LastName;
    }

    public bool CheckProfile(string FirstName, string LastName, string EmailAdress = null)
    {
        if (EmailAdress == null)
            return this.MyFullName.FirstName == FirstName && this.MyFullName.LastName == LastName;
        return this.MyFullName.FirstName == FirstName && this.MyFullName.LastName == LastName && this.EmailAdress == EmailAdress;
    }

    public virtual string GetPassengerType()
    {
        {
            return "I'm a passenger";
        }
    }
}