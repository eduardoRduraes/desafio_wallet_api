using WalletAPI.Data;
using WalletAPI.Models;

namespace WalletAPI.Services;

public class WalletServices
{
    private readonly AppDbContext _context;
    
    public WalletServices(AppDbContext context)
    {
        _context = context;
    }

    public decimal GetBalance(Guid userId)
    {
        var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == userId);
        if(wallet == null)
                throw new Exception("Wallet not found");
        
        return wallet.Balance;
    }

    public void AddBalance(Guid userId, decimal amount)
    {
        if(amount < 0)
            throw new Exception("Invalid amount");
        
        var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == userId);
        if(wallet == null)
            throw new Exception("Wallet not found");
        
        wallet.Balance += amount;
        _context.SaveChanges();
    }

    public void Transfer(Guid senderWalletId, Guid receivedWalletId, decimal amount)
    {
        if( amount <= 0 )
            throw new Exception("Invalid amount");
        
        
        var senderWallet = _context.Wallets.FirstOrDefault(w => w.UserId == senderWalletId);
        var receiverWallet = _context.Wallets.FirstOrDefault(w => w.UserId == receivedWalletId);
        
        if(senderWallet == null)
            throw new Exception("Wallet not found");
        
        if(receiverWallet == null)
            throw new Exception("Wallet not found");
        
        if(senderWallet.Balance < amount)
            throw new Exception("Not enough balance");
        
        senderWallet.Balance -= amount;
        receiverWallet.Balance += amount;

        var transaction = new Transaction
        {
            SenderWalletId = senderWallet.Id,
            ReceiverWalletId = receiverWallet.Id,
            Amount = amount,
        };
        
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public IEnumerable<Transaction> GetTransactionHistory(Guid userId, DateTime? startDate, DateTime? endDate)
    {
        var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == userId);
        if(wallet == null)
            throw new Exception("Wallet not found");

        var transactions = _context.Transactions.Where(t => t.SenderWalletId == wallet.Id).AsParallel();
        
        if(startDate.HasValue)
            transactions = transactions.Where(t => t.Date >= startDate.Value);

        if (endDate.HasValue)
        {
            transactions = transactions.Where(t => t.Date <= endDate.Value);
        }
        
        return transactions.OrderByDescending(t => t.Date).ToList();
    }
}