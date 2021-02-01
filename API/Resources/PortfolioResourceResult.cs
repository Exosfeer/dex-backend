using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Resources
{
    /// <summary>
    /// The view model result of portfolio
    /// </summary>
    public class PortfolioResourceResult
    {
        /// <summary>
        /// This sets or gets the user of the portfolio Resource result id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This sets or gets the username of the portfolio
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// This sets or gets the username of the portfolio
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// This sets or gets the template of the portfolio
        /// </summary>
        public int Template { get; set; }

        /// <summary>
        /// This sets or gets the portfolio icon
        /// </summary>
        public int? Icon { get; set; }

        /// <summary>
        /// this sets or gets the portfolio title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// this sets or gets the portfolio Uri
        /// </summary>
        public string PublicUri { get; set; }

        /// <summary>
        /// this sets or gets the PortfolioItems
        /// </summary>
        public List<PortfolioItemResourceResult> PortfolioItem { get; set; }
    }
}