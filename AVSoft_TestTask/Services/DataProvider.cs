using AVSoft_TestTask.Context;
using AVSoft_TestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVSoft_TestTask.Services
{
	public class DataProvider : IDataProvider
	{
		private readonly AVSoftContext context;
		public DataProvider(AVSoftContext context)
		{
			this.context = context;
		}
		//Добавление новых записей в таблицу Counters
		public void AddData(int key, int value)
		{
			Counter newItem = new Counter() { Key = key, Value = value };
			context.Counters.Add(newItem);
			context.SaveChanges();
		}
		//Запрос данных из таблицы Counters
		public List<Counter> GetCounters()
		{
			List<Counter> counters = new List<Counter>();
			counters = context.Counters.ToList<Counter>();
			return counters;
		}


		//Запрос, возвращающий количество записей по столбцу Key 
		//и счетчик значений больше единицы 

		/*
			Select T1.[Key],T1.[Count],T2.[CountMoreTheOne] from 
			(Select [Key], COUNT([Key]) as 'Count' from Counters Group by [Key]) T1,
			(Select [Key], COUNT([Value]) as 'CountMoreTheOne'from Counters where [Value]>1 Group by [Key]) T2
			where T1.[Key] =T2.[Key]
		 */
		public List<SpecialRequestViewModel> SpecialRequest()
		{
			List<SpecialRequestViewModel> _specialRequest = (from c1 in context.Counters
															 group c1 by c1.Key into c
															 orderby c.Key
															 select new SpecialRequestViewModel
															 {
																 Key = c.Key,
																 Count = c.Count()
															 }).ToList();

			var countMoreTheOne = (from c1 in context.Counters
								   where c1.Value > 1
								   group c1 by c1.Key into c
								   orderby c.Key
								   select new
								   {
									   Key = c.Key,
									   CountMoreTheOne = c.Count()
								   }).ToList();

			for (int i = 0; i < _specialRequest.Count; i++)
				_specialRequest[i].CountMoreTheOne = countMoreTheOne[i].CountMoreTheOne;

			return _specialRequest;
		}

		
	}
}
