using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CodingAssignment.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		[HttpGet]
		[Route("Listify/{begin:int}/{end:int}/{index:int}")]
		public IActionResult Listify(int begin, int end, int index)
		{
			var list = new Listify(begin, end);
			var res = list.Where(rec => rec == list[index]);
			return Ok(res);
		}
	}

	public class Listify : IEnumerable<int>
	{
		private IEnumerable<int> _list;

		public int this[int index] => _list.ElementAt(index);

		public Listify(int start, int count)
		{
			_list = Enumerable.Range(start, count);
		}

		public IEnumerator<int> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
