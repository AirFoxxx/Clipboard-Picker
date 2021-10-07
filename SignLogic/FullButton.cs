using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLogic
{
    /// <summary>
    /// Class represents one Button on the grid.
    /// </summary>
    public class FullButton
    {
        /// <summary>
        /// The identifier counter. Starts at one.
        /// </summary>
        public static int IdCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="FullButton"/> class.
        /// </summary>
        public FullButton()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FullButton"/> class.
        /// </summary>
        /// <param name="buttonSign">The main button sign to display.</param>
        /// <param name="buttonDesc">The button description.</param>
        public FullButton(string buttonSign, string buttonDesc)
        {
            this.Id = IdCounter++;
            this.Sign = buttonSign;
            this.Description = buttonDesc;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the sign.
        /// </summary>
        /// <value>
        /// The sign.
        /// </value>
        public string Sign { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
