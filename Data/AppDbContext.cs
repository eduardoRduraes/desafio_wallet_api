using Microsoft.EntityFrameworkCore;
using WalletAPI.Models;

namespace WalletAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.SenderWallet)
            .WithMany()
            .HasForeignKey(t => t.SenderWalletId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.ReceivedWallet)
            .WithMany()
            .HasForeignKey(t => t.ReceiverWalletId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    
}