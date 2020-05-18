using System;
using System.Collections.Generic;

namespace OpenShop
{
   
    class GestorVenta
    {
        static ItemCarrito items;
         static Carrito Carrito= new Carrito(items);
        static void Main(string[] args)
        {
        
            while (true)
            {
               MostrarProductos();
               var resultado = AgregarAlCarrito();
               if (!resultado)
               {
                   break;
               }
            }

            System.Console.WriteLine("Gracias por comprar");
        }

       static void MostrarProductos()
       {
          foreach (var producto in RegistroProductos.Productos)
          {
              System.Console.WriteLine(producto.CodigoProducto +' '+ producto.Nombre + "  $ " + producto.Precio);
          }   
       }

       static bool AgregarAlCarrito()
       {
           System.Console.WriteLine("Seleccione Codigo del producto");
           string seleccion = System.Console.ReadLine();
           if (string.IsNullOrEmpty(seleccion))
           {
               return false;
           }

            var producto = RegistroProductos.Productos[int.Parse(seleccion) - 1];
            System.Console.WriteLine("Seleccione la Cantidad deseada");          
            items.AgregarItem(producto,int.Parse(Console.ReadLine()));
            System.Console.Clear();
            Carrito.MostrarCarrito();

           return true;
       }

    }

    class RegistroProductos
    {
        public static List<Producto> Productos = new List<Producto>();

        static RegistroProductos()
        {
            Productos.Add(new Producto(1,"Cafetera", 3000));
            Productos.Add(new Producto(2,"Celular", 249999.99m));
            Productos.Add(new Producto(3,"Televisor", 22000));
            Productos.Add(new Producto(4,"Ojotas", 700));
        }
    }

    class Producto
    {
      public int CodigoProducto;
       public string Nombre;
       public decimal Precio;

       public Producto(int codigoproducto,string nombre, decimal precio)
       {
           Nombre = nombre;
           Precio = precio;
           CodigoProducto=codigoproducto;
       }
         public string getNombre(){
            return(Nombre);
        }
        public void setNombre(String nombre){
            Nombre=nombre;
        }
        public decimal getPrecio(){
            return(Precio);
        }
        public void setPrecio(decimal precio){
            Precio=precio;
        }
        public int getCodigoProducto(){
            return(CodigoProducto);
        }
        public void setCodigoProducto(int codigoproducto){
            CodigoProducto=codigoproducto;
        }
    }

    class Carrito
    {
       private ItemCarrito ProductosEnCarrito;
       public Carrito(ItemCarrito items){
           ProductosEnCarrito=items;
       }
       public void MostrarCarrito()
       {
          System.Console.WriteLine("Tienes en tu carrito: ");

           for(int i=0;i<ProductosEnCarrito.getProductosItem().Count;i++)
           {
               System.Console.WriteLine(ProductosEnCarrito.getCantidades()[i]+' '+ ProductosEnCarrito.getProductosItem()[i].getNombre()+' '+ ProductosEnCarrito.getCantidades()[i]*ProductosEnCarrito.getProductosItem()[i].getPrecio());
           }
       }
    }

    class ItemCarrito
    {
        private List<int> Cantidades;
        private List<Producto> ProductosItem;

        public ItemCarrito(Producto producto,int cantidad){
            Cantidades.Add(cantidad);
            ProductosItem.Add(producto);
        }

        public List<int> getCantidades(){
            return(Cantidades);
        }
        public void setCantidades(int cantidad,int i){
            Cantidades[i]=cantidad;
        }
        public List<Producto> getProductosItem(){
            return(ProductosItem);
        }
        public void setProductosItem(Producto producto,int i){
            ProductosItem[i]=producto;
        }
        public void AgregarItem(Producto producto,int cantidad)
        {    
            //Si el producto ya esta en el carrito no lo agrega de vuelta sino que suma la cantidad
            for(int i=0;i < ProductosItem.Count;i++){
                if(producto.getCodigoProducto()==ProductosItem[i].getCodigoProducto()){
                    Cantidades[i]=Cantidades[i]+cantidad;
                    return;
                }
            }
            ProductosItem.Add(producto);
            Cantidades.Add(cantidad);
        }

    }
}

