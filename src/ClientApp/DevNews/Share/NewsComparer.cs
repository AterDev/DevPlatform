using DevNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNews.Share
{
    public class NewsComparer : IEqualityComparer<ThirdNews>
    {
        public bool Equals(ThirdNews x, ThirdNews y)
        {
            return x.Title == y.Title;

        }

        public int GetHashCode(ThirdNews obj)
        {
            return obj.Title.GetHashCode();
        }
    }
}
