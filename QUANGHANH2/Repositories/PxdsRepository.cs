using System;
using System.Collections.Generic;
using System.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.Utils;
using Unity;

namespace QUANGHANH2.Repositories
{
    public class PxdsRepository : IPxdsRepository
    {
        [Dependency]
        public QUANGHANHABCEntities Context { get; set; }
        
        public IList<PxdsModelView> GetDetails()
        {
            var details = Context.Database.SqlQuery<PxdsModelView>($"" +
                $"SELECT d.department_id DepartmentId, d.department_name DepartmentName, 0 AS RegMonday, 0 AS RegTuesday, 0 AS RegWednesday, 0 AS RegThursday, 0 AS RegFriday, 0 AS RegSaturday, 0 AS RegSunday, 0 AS RegMondayPlan, 0 AS RegTuesdayPlan, 0 AS RegWednesdayPlan, 0 AS RegThursdayPlan, 0 AS RegFridayPlan, 0 AS RegSaturdayPlan, 0 AS RegSundayPlan " +
                $"FROM Department d").ToList();
            var timeHelper = new TimeHelper();
            DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
            if (HasMealRegistration(mondayOfNextWeek))
            {
                var mealRegistrations = Context.Database.SqlQuery<PxdsMealRegistrationModelView>($"" +
                    $"SELECT mr.id Id, mr.department_id DepartmentId, mr.date_regs DateRegistration, mr.num_regs NumOfMealRegistrations, mr.num_regs_plan NumOfMealRegistrationsPlan " +
                    $"FROM MealRegistration mr " +
                    $"WHERE date_regs BETWEEN '{mondayOfNextWeek.Date}' AND '{mondayOfNextWeek.AddDays(5).Date}'").ToList();
                // convert PxdsMealRegistrationModelView to PxdsModelView
                foreach (var reg in details)
                {
                    foreach(var meal in mealRegistrations)
                    {
                        if (reg.DepartmentId.Equals(meal.DepartmentId))
                        {
                            if (meal.DateRegistration.Equals(mondayOfNextWeek))
                            {
                                reg.RegMonday = meal.NumOfMealRegistrations;
                                reg.RegMondayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                            if (meal.DateRegistration.Equals(mondayOfNextWeek.AddDays(1)))
                            {
                                reg.RegTuesday = meal.NumOfMealRegistrations;
                                reg.RegTuesdayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                            if (meal.DateRegistration.Equals(mondayOfNextWeek.AddDays(2)))
                            {
                                reg.RegWednesday = meal.NumOfMealRegistrations;
                                reg.RegWednesdayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                            if (meal.DateRegistration.Equals(mondayOfNextWeek.AddDays(3)))
                            {
                                reg.RegThursday = meal.NumOfMealRegistrations;
                                reg.RegThursdayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                            if (meal.DateRegistration.Equals(mondayOfNextWeek.AddDays(4)))
                            {
                                reg.RegFriday = meal.NumOfMealRegistrations;
                                reg.RegFridayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                            if (meal.DateRegistration.Equals(mondayOfNextWeek.AddDays(5)))
                            {
                                reg.RegSaturday = meal.NumOfMealRegistrations;
                                reg.RegSaturdayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                            if (meal.DateRegistration.Equals(mondayOfNextWeek.AddDays(6)))
                            {
                                reg.RegSunday = meal.NumOfMealRegistrations;
                                reg.RegSundayPlan = meal.NumOfMealRegistrationsPlan;
                            }
                        }
                    }
                }
            }
            return details;
        }

        public bool SaveMealRegistration(IList<PxdsModelView> details)
        {
            //TODO: should use bulk insert linq. timeless.
            try
            {
                string bulk_insert = string.Empty;
                var timeHelper = new TimeHelper();
                DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
                foreach(var reg in details)
                {
                    //Monday
                    string sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.Date.ToString()}', {reg.RegMonday}, {reg.RegMondayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                    //Tuesday
                    sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.AddDays(1).Date.ToString()}', {reg.RegTuesday}, {reg.RegTuesdayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                    //Wednesday
                    sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.AddDays(2).Date.ToString()}', {reg.RegWednesday}, {reg.RegWednesdayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                    //Thursday
                    sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.AddDays(3).Date.ToString()}', {reg.RegThursday}, {reg.RegThursdayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                    //Friday
                    sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.AddDays(4).Date.ToString()}', {reg.RegFriday}, {reg.RegFridayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                    //Saturday
                    sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.AddDays(5).Date.ToString()}', {reg.RegSaturday}, {reg.RegSaturdayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                    //Sunday
                    sub_insert = $"INSERT INTO MealRegistration(department_id, date_regs, num_regs, num_regs_plan) VALUES('{reg.DepartmentId}', '{mondayOfNextWeek.AddDays(6).Date.ToString()}', {reg.RegSunday}, {reg.RegSundayPlan});";
                    bulk_insert = string.Concat(bulk_insert, sub_insert);
                }
                Context.Database.ExecuteSqlCommand(bulk_insert);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateMealRegistration(IList<PxdsModelView> details)
        {
            try
            {
                string bulk_update = string.Empty;
                var timeHelper = new TimeHelper();
                DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
                foreach (var reg in details)
                {
                    //Monday
                    string sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegMonday}, num_regs_plan = {reg.RegMondayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                    //Tuesday
                    sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegTuesday}, num_regs_plan = {reg.RegTuesdayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.AddDays(1).Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                    //Wednesday
                    sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegWednesday}, num_regs_plan = {reg.RegWednesdayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.AddDays(2).Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                    //Thursday
                    sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegThursday}, num_regs_plan = {reg.RegThursdayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.AddDays(3).Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                    //Friday
                    sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegFriday}, num_regs_plan = {reg.RegFridayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.AddDays(4).Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                    //Saturday
                    sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegSaturday}, num_regs_plan = {reg.RegSaturdayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.AddDays(5).Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                    //Sunday
                    sub_update = $"UPDATE MealRegistration SET num_regs = {reg.RegSunday}, num_regs_plan = {reg.RegSundayPlan} WHERE department_id = '{reg.DepartmentId}' AND date_regs = '{mondayOfNextWeek.AddDays(6).Date.ToString()}';";
                    bulk_update = string.Concat(bulk_update, sub_update);
                }
                Context.Database.ExecuteSqlCommand(bulk_update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool HasMealRegistration(DateTime mondayOfNextWeek)
        {
            return Context.Database.SqlQuery<int?>($"SELECT COUNT(1) FROM MealRegistration WHERE date_regs = '{mondayOfNextWeek.Date}'").First() > 0;
        }
    }
}