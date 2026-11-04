using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//no linking classes because its its own function following result of user model
namespace PROJECT1.Service
{
    class TherapistServices
    {
        public int CalculateTherapistSalary (int sessions_done)
        {
            int ratePerSession = 2500;
            float clinic_tax = (0.20F);
            float gov_tax = (0.07F);

            float total_before_tax = ratePerSession * sessions_done;

            float after_clinic_cut = total_before_tax - (total_before_tax * clinic_tax); //therapist gets 80% pay

            float after_taxes = after_clinic_cut - (after_clinic_cut * gov_tax); //7% gov tax

            return Convert.ToInt32(after_taxes); //actual payment received

        }
    }
}
