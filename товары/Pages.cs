using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace товары
{
    public class Pages
    {
        private static connection connection;

        private static StartPage startPage;
        private static ProductPage productPage;
        private static CategoryPage categoryPage;
        private static ProductList productList;

        public static connection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new connection();
                }
                return connection;
            }
        }
        public static StartPage Start
        {
            get
            {
                if (startPage == null) {
                    startPage = new StartPage(Connection);
                }
                return startPage;
            }
        }
        public static ProductPage Product
        {
            get
            {
                if (productPage == null) {
                    productPage = new ProductPage(Connection);
                }
                return productPage;
            }
        }
        public static CategoryPage Category
        {
            get
            {
                if (categoryPage == null)
                {
                    categoryPage = new CategoryPage(Connection);
                }
                return categoryPage;
            }
        }
        public static ProductList ProductList
        {
            get
            {
                if (productList == null)
                {
                    productList = new ProductList(Connection);
                }
                return productList;
            }
        }
    }
}
