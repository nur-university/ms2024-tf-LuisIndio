using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Domain.Model
{
    public class DietaryPlan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public PlanDuration Duration { get; private set; }
        public PlanStatus Status { get; private set; }
        public List<AssignedRecipe> Recipes { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public DietaryPlan(Guid id, string name, PlanDuration duration, DateTime createdDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name of the dietary plan cannot be null or empty.");
      

            Id = id;
            Name = name;
            Duration = duration;
            Status = PlanStatus.Active;
            Recipes = new List<AssignedRecipe>();
            CreatedDate = createdDate;
            StartDate = null;
            EndDate = null;
        }
        public void AddRecipe(AssignedRecipe assignedRecipe)
        {
            if (assignedRecipe == null)
                throw new ArgumentNullException(nameof(assignedRecipe), "The recipe cannot be null.");

            Recipes.Add(assignedRecipe);
        }
        public void UpdateStatus(PlanStatus newStatus)
        {
            Status = newStatus;
        }
        
        public void RemoveRecipe(Guid recipeId)
        {
            Recipes.RemoveAll(r => r.RecipeId == recipeId);
        }

        private DietaryPlan() { }
    }
    public enum PlanStatus
    {
        Active,
        Completed,
        Canceled
    }
    public class AssignedRecipe
    {
        public Guid Id { get; private set; }
        public Guid RecipeId { get; private set; }
        public MealTime MealTime { get; private set; }
        public int Quantity { get; private set; }

        public AssignedRecipe(Guid id, Guid recipeId, MealTime mealTime, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            Id = id;
            RecipeId = recipeId;
            MealTime = mealTime;
            Quantity = quantity;
        }
    }
    public enum MealTime
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack
    }
}
