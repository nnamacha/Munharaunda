using Microsoft.EntityFrameworkCore;
using Munharaunda.Domain.Models;
using System;

namespace Munharaunda.Infrastructure.Database
{
    [System.Runtime.InteropServices.Guid("58433C8E-1157-4C59-A6C5-2183C3C1C578")]
    public static class ModelBuilderExtensions
    {
              

        


        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Funeral>().HasData(
                    new Funeral
                    {
                        FuneralId = 1,
                        DeceasedsProfileNumber = 5,
                        AddressForFuneral = "15 Albany Crescent Warren Park",
                        StatusId = 5,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Comment = "Test Funeral"
                    },
                    new Funeral
                    {
                        FuneralId = 2,
                        DeceasedsProfileNumber = 4,
                        AddressForFuneral = "15 Albany Crescent Warren Park",
                        StatusId = 3,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Comment = "Test Funeral"
                    }

                );
            modelBuilder.Entity<Statuses>().HasData
             (
                new Statuses { StatusId = 1, StatusDescription = "Terminated", CreatedBy = 1 },
                new Statuses { StatusId = 2, StatusDescription = "Pending Authorisation", CreatedBy = 1 },
                new Statuses { StatusId = 3, StatusDescription = "Active", CreatedBy = 1 },
                new Statuses { StatusId = 4, StatusDescription = "Inarrears", CreatedBy = 1 },
                new Statuses { StatusId = 5, StatusDescription = "Closed", CreatedBy = 1 },
                new Statuses { StatusId = 6, StatusDescription = "Authorised", CreatedBy = 1 }

            );

            modelBuilder.Entity<ProfileTypes>().HasData
                (
                    new ProfileTypes { ProfileTypeId = 1, Description = "Admin" },
                    new ProfileTypes { ProfileTypeId = 2, Description = "Member" },
                    new ProfileTypes { ProfileTypeId = 3, Description = "NextOfKin" },
                    new ProfileTypes { ProfileTypeId = 4, Description = "Dependent" },
                    new ProfileTypes { ProfileTypeId = 5, Description = "ColdBody"},
                    new ProfileTypes { ProfileTypeId = 6, Description = "Alpha"}


                );
            modelBuilder.Entity<IdentityTypes>().HasData
                (
                    new IdentityTypes { IdentityTypeId = 1, Description = "Id"},
                    new IdentityTypes { IdentityTypeId = 2, Description = "PassPort"}
                    
                
                );

            modelBuilder.Entity<Profile>().HasData
                (
                    new Profile 
                    {
                        ActiveDate = new DateTime(2021, 1, 1),
                        Address = "15 Albany Crescent Parklands CapeTown",
                        Approve1 = new DateTime(2021, 1, 1),
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        DateOfBirth = new DateTime(2021, 1, 1),
                        IdentityNumber = "System",
                        ProfileTypeId = 5,
                        PhoneNumber = "000000000000",
                        ProfileNumber = 1,
                        Name = "Alpha",
                        ReOpen = false,
                        Status = 3,
                        Surname = "System"
                        

                    },
                    new Profile
                    {
                        ActiveDate = new DateTime(2021, 1, 1),
                        Address = "15 Albany Crescent Parklands CapeTown",
                        Approve1 = new DateTime(2021, 1, 1),
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        DateOfBirth = new DateTime(2021, 1, 1),
                        IdentityNumber = "System",
                        ProfileTypeId = 5,
                        PhoneNumber = "000000000000",
                        ProfileNumber = 2,
                        Name = "Test",
                        ReOpen = false,
                        Status = 3,
                        Surname = "User1"
                    },

                    new Profile
                    {
                        ActiveDate = new DateTime(2021, 1, 1),
                        Address = "15 Albany Crescent Parklands CapeTown",
                        Approve1 = new DateTime(2021, 1, 1),
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        DateOfBirth = new DateTime(1982, 8, 24),
                        IdentityNumber = "MA9XX057XX",
                        IdentityTypeId = 2,
                        ProfileTypeId = 6,
                        PhoneNumber = "0846994704",
                        ProfileNumber = 3,
                        Name = "Nicholas",
                        ReOpen = false,
                        Status = 3,
                        Surname = "Namacha"
                    },
                    new Profile
                    {
                        ActiveDate = new DateTime(2021, 1, 1),
                        Address = "15 Albany Crescent Parklands CapeTown",
                        Approve1 = new DateTime(2021, 1, 1),
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        DateOfBirth = new DateTime(2021, 1, 1),
                        IdentityNumber = "System",
                        ProfileTypeId = 5,
                        PhoneNumber = "000000000000",
                        ProfileNumber = 4,
                        Name = "Test",
                        ReOpen = false,
                        Status = 3,
                        Surname = "User2"
                    },
                    new Profile
                    {
                        ActiveDate = new DateTime(2021, 1, 1),
                        Address = "15 Albany Crescent Parklands CapeTown",
                        Approve1 = new DateTime(2021, 1, 1),
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        DateOfBirth = new DateTime(2021, 1, 1),
                        IdentityNumber = "System",
                        ProfileTypeId = 5,
                        PhoneNumber = "000000000000",
                        ProfileNumber = 5,
                        Name = "Test",
                        ReOpen = false,
                        Status = 5,
                        Surname = "User3"
                    }

                );
            modelBuilder.Entity<TransactionCodes>().HasData
                (
                    new TransactionCodes
                    {
                        Contribution = true,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = true,
                        TransactionCodeId = 1,
                        Description = "Funeral Contribution",
                        Status = 6,
                        
                    },
                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = false,
                        TransactionCodeId = 2,
                        Description = "Funeral Expense",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = true,
                        TransactionCodeId = 3,
                        Description = "Joining Fee",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = true,
                        TransactionCodeId = 4,
                        Description = "Debit Reversal",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = false,
                        TransactionCodeId = 5,
                        Description = "Credit Reversal",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = false,
                        TransactionCodeId = 6,
                        Description = "Joining Fee Reversal",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = true,
                        TransactionCodeId = 7,
                        Description = "Expense Reversal",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = false,
                        TransactionCodeId = 8,
                        Description = "General Expense",
                        Status = 6,

                    },

                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = true,
                        TransactionCodeId = 9,
                        Description = "Deposit",
                        Status = 6,

                    },


                    new TransactionCodes
                    {
                        Contribution = false,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 1,
                        Credit = true,
                        TransactionCodeId = 10,
                        Description = "Funeral PayOut",
                        Status = 6,

                    }

                );

            modelBuilder.Entity<Transactions>().HasData
                (
                    new Transactions
                    {
                        Amount = 100,
                        Contribution = true,
                        Created = new DateTime(2021, 1, 1),
                        CreatedBy = 3,
                        TransactionCode = 1,
                        FuneralId = 1,
                        TransactionId =1

                    },
                     new Transactions
                     {
                         Amount = 100,
                         Contribution = true,
                         Created = new DateTime(2021, 1, 1),
                         CreatedBy = 2,
                         TransactionCode = 1,
                         FuneralId = 1,
                         TransactionId = 2

                     },
                      new Transactions
                      {
                          Amount = 100,
                          Contribution = true,
                          Created = new DateTime(2021, 1, 1),
                          CreatedBy = 3,
                          TransactionCode = 1,
                          FuneralId = 1,
                          TransactionId = 3

                      },
                       new Transactions
                       {
                           Amount = 100,
                           Contribution = true,
                           Created = new DateTime(2021, 1, 1),
                           CreatedBy = 4,
                           TransactionCode = 1,
                           FuneralId = 1,
                           TransactionId = 4

                       },
                        new Transactions
                        {
                            Amount = 100,
                            Contribution = true,
                            Created = new DateTime(2021, 1, 1),
                            CreatedBy = 3,
                            TransactionCode = 1,
                            FuneralId = 2,
                            TransactionId = 5

                        }
                );

        }
    }
}
