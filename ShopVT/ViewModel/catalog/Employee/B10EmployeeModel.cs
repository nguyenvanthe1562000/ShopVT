﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace ViewModel.catalog.Employee
{
     public class EmployeeRequest
     {
       	
	public int ID { set; get; }
	public string code { set; get; }
	public string Name { set; get; }
	public string Name2 { set; get; }
	public IFormFile Image { set; get; }
	public DateTime BirthDate { set; get; }
	public string Address { set; get; }
	public int IdCardNo { set; get; }
	public DateTime IdCardDate { set; get; }
	public string IdCardIssuePlace { set; get; }
	public int BankAccount { set; get; }
	public string BankName { set; get; }
	public string Tel1 { set; get; }
	public string Tel2 { set; get; }
	public int MarriageStatus { set; get; }
	public string Email { set; get; }
	public int Gender { set; get; }



     }
}


