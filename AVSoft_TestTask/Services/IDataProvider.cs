using AVSoft_TestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVSoft_TestTask.Services
{
	public interface IDataProvider
	{
		List<Counter> GetCounters();
		void AddData(int key, int value);
		List<SpecialRequestViewModel> SpecialRequest();	
	}
}
