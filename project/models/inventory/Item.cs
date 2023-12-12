
namespace project.models.inventory
{
    public class Item
    {
        private int quantity;

        public string Name { get; set; }
        public string Description { get; set; }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                // Se a quantidade for menor ou igual a 0, o item é removido do inventário
                if (quantity <= 0)
                {
                    RemoveFromInventory();
                }
            }
        }

        private void RemoveFromInventory()
        {
            // Lógica para remover o item do inventário
            Console.WriteLine($"Item '{Name}' removido do inventário.");
            // Aqui você pode adicionar a lógica específica para remover o item do inventário.
            // Por exemplo, você pode ter uma lista de itens no inventário e remover este item da lista.
        }
    }
}

