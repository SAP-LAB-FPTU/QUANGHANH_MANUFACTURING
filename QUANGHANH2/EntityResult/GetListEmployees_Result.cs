using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.EntityResult
{
    public class GetListEmployees_Result
    {
        public string employee_id { get; set; }
        public string BASIC_INFO_full_name { get; set; }
        public string BASIC_INFO_other_name { get; set; }
        public Nullable<bool> BASIC_INFO_gender { get; set; }
        public Nullable<System.DateTime> BASIC_INFO_date_of_birth { get; set; }
        public string BASIC_INFO_place_of_birth { get; set; }
        public string BASIC_INFO_nation { get; set; }
        public string BASIC_INFO_home_town { get; set; }
        public string BASIC_INFO_religion { get; set; }
        public string BASIC_INFO_registered_place_of_permanent_residence { get; set; }
        public string BASIC_INFO_current_residence { get; set; }
        public string BASIC_INFO_phone_number { get; set; }
        public string BASIC_INFO_wounded_class { get; set; }
        public string BASIC_INFO_policy_family_child { get; set; }
        public string BASIC_INFO_identity_card { get; set; }
        public Nullable<System.DateTime> BASIC_INFO_date_of_issuance_of_identity_card { get; set; }
        public string BASIC_INFO_social_insurance_number { get; set; }
        public string RECRUITMENT_profession { get; set; }
        public Nullable<System.DateTime> RECRUITMENT_date { get; set; }
        public string RECRUITMENT_company { get; set; }
        public string JOB_instant_position { get; set; }
        public string JOB_work { get; set; }
        public string JOB_civil_servants { get; set; }
        public string JOB_code_ranks { get; set; }
        public string JOB_pay_rate { get; set; }
        public string JOB_coefficients_salary { get; set; }
        public Nullable<System.DateTime> JOB_date { get; set; }
        public string JOB_position_allowance { get; set; }
        public string JOB_other_allowances { get; set; }
        public string JOB_forte_of_work { get; set; }
        public string ACADEMIC_academic_level { get; set; }
        public string ACADEMIC_highest_qualification { get; set; }
        public string ACADEMIC_political_theory { get; set; }
        public string ACADEMIC_state_management { get; set; }
        public string ACADEMIC_languages { get; set; }
        public string ACADEMIC_information_technology { get; set; }
        public Nullable<System.DateTime> PARTY_day_on_VCP { get; set; }
        public Nullable<System.DateTime> PARTY_official_date { get; set; }
        public Nullable<System.DateTime> PARTY_date_of_joining_political_social_organization { get; set; }
        public Nullable<System.DateTime> PARTY_date_of_enlistment { get; set; }
        public Nullable<System.DateTime> PARTY_date_of_discharge { get; set; }
        public string PARTY_highest_rank { get; set; }
        public string PARTY_highest_achieved_title { get; set; }
        public string EVALUATION_bonus { get; set; }
        public string EVALUATION_discipline { get; set; }
        public string HEALTH_health_condition { get; set; }
        public string HEALTH_height { get; set; }
        public string HEALTH_weight { get; set; }
        public string HEALTH_blood_group { get; set; }
        public string PERSONAL_HISTORY_detail { get; set; }
        public string PERSONAL_HISTORY_related_organization { get; set; }
        public string PERSONAL_HISTORY_relatives { get; set; }
        public Nullable<int> current_status_id { get; set; }
        public string current_department_id { get; set; }
        public Nullable<int> current_salary_id { get; set; }
        public Nullable<int> current_work_id { get; set; }
        public string StatusName { get; set; }
        public string rate_table_level { get; set; }
        public string salary_number { get; set; }
        public string pay_rate { get; set; }
        public string pay_table { get; set; }
        public string work { get; set; }
    }
}