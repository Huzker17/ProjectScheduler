using BL.DTOs.Projects;
using DAL.Models;
using System.Linq.Expressions;

namespace BL.Utils;
public static class IQueryableExtension
{
	public static IQueryable<Project> ApplyFilter(this IQueryable<Project> list, Filters filters)
	{
		return list.Where(x => x.StartDate > filters.StartDate && x.EndDate < filters.EndDate &&
						x.Priority == filters.Priority);
	}
	public static IOrderedQueryable<TSource> SortRows<TSource, TKey>(this IQueryable<TSource> rows,
	Expression<Func<TSource, TKey>> keySelector, bool? isAscSorting)
	=> isAscSorting == true ? rows.OrderBy(keySelector) : rows.OrderByDescending(keySelector);
}
