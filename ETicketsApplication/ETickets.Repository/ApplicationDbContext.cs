using ETickets.Domain.DomainModels;
using ETickets.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;

namespace ETickets.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ETicketsApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*ovie konfiguracie koi kje gi pravime so fluent APi mozhe i so [Required] pred sekoja karakteristika*/

            /*builder.Entity<Product>()
                .Property(z => z.ProductName)
                .IsRequired();*/
            /*generiranje na id*/
            builder.Entity<Ticket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
               .Property(z => z.Id)
               .ValueGeneratedOnAdd();

            /*kompoziten kluch*/

            //builder.Entity<ProductInShoppingCart>()
            //    .HasKey(z => new { z.ProductId, z.ShoppingCartId });

            builder.Entity<TicketInShoppingCart>()
                .HasOne(z => z.Ticket)
                .WithMany(z => z.TicketInShoppingCart)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<TicketInShoppingCart>()
               .HasOne(z => z.ShoppingCart)
               .WithMany(z => z.TicketInShoppingCarts)
               .HasForeignKey(z => z.TicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<ETicketsApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);



            //builder.Entity<ProductInOrder>()
            //    .HasKey(z => new { z.ProductId, z.OrderId });

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.OrderedTicket)
                .WithMany(z => z.TicketInOrders)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<TicketInOrder>()
               .HasOne(z => z.UserOrder)
               .WithMany(z => z.TicketInOrders)
               .HasForeignKey(z => z.TicketId);
            /*do tuka site realcii*/
        }
    }
}
