using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shiftwise._52cards.mvc.repository
{
    public static class ListExtensions
    {
        //http://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
        // https://blog.codinghorror.com/the-danger-of-naivete/   
        public static void Shuffle<T>(this IList<T> list, Random rnd)
        {
            for (var i = 0; i < list.Count; i++)
                list.Swap(i, rnd.Next(i, list.Count));
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        } 
    }
}