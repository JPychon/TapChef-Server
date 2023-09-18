namespace TapChef_Backend.DTOs.Components
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; } = default!;
        public int DishId { get; set; }
        public Dish Dish { get; set; } = default!;
    }
}
