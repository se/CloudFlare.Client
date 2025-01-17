using System.Linq;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AccountUnitTests
    {
        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(0, null, null)]
        [InlineData(null, 100, null)]
        [InlineData(null, null, OrderType.Asc)]
        [InlineData(null, null, OrderType.Desc)]
        [InlineData(null, null, null)]
        public static void TestGetAccountsAsync(int? page, int? perPage, OrderType? order)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync(page, perPage, order).Result;

                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetAccountDetailsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var accountDetails = client.GetAccountDetailsAsync(accounts.Result.First().Id).Result;

                Assert.NotNull(accountDetails);
                Assert.Empty(accountDetails.Errors);
                Assert.True(accountDetails.Success);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void UpdateAccountAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var updatedAccount = client.UpdateAccountAsync(accounts.Result.First().Id, accounts.Result.First().Name).Result;

                Assert.NotNull(updatedAccount);
                Assert.Empty(updatedAccount.Errors);
                Assert.True(updatedAccount.Success);
            }
        }
    }
}
