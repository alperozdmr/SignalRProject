using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.Contact
{
	public class CreateContactDto
	{

        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterTitle { get; set; }
        public string FooterDescription { get; set; }
        public string OpenDay { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHour { get; set; }
    }
}
