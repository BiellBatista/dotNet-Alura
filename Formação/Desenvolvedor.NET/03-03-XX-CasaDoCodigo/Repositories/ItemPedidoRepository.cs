﻿using _03_03_XX_CasaDoCodigo.Models;
using System.Linq;

namespace _03_03_XX_CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return dbSet.Where(ip => ip.Id == itemPedidoId).SingleOrDefault();
        }
    }
}
