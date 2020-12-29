using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetOutside_Excel_Result
    {
        public string employee_id { get; set; }
        public string BASIC_INFO_full_name { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public string department_name { get; set; }
        public string BASIC_INFO_phone_number { get; set; }
        public string BASIC_INFO_current_residence { get; set; }
        public string BASIC_INFO_social_insurance_number { get; set; }
        public string termination_name { get; set; }
        public string decision_number { get; set; }
        public Nullable<System.DateTime> decision_date { get; set; }
        public Nullable<System.DateTime> terminate_date { get; set; }
        public string au_full_name { get; set; }
        public string au_identity_card_number { get; set; }
        public string au_phone_number { get; set; }
        public string family_relationship_name { get; set; }
        public string papers_number { get; set; }
        public string paper_name { get; set; }
        public string type_name { get; set; }
        public Nullable<System.DateTime> given_date { get; set; }
        public Nullable<System.DateTime> received_date { get; set; }
    }
}