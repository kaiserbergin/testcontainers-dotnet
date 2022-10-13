namespace DotNet.Testcontainers.Tests.Fixtures
{
  using System;
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;
  using Xunit;

  [UsedImplicitly]
  public sealed class LocalStackFixture : IAsyncLifetime, IDisposable
  {
    private readonly LocalStackTestcontainerConfiguration configuration = new LocalStackTestcontainerConfiguration();

    public LocalStackFixture()
    {
      this.Container = new TestcontainersBuilder<LocalStackTestcontainer>()
        .WithMessageBroker(this.configuration)
        .Build();
    }

    public LocalStackTestcontainer Container { get; }

    public Task InitializeAsync()
    {
      return this.Container.StartAsync();
    }

    public Task DisposeAsync()
    {
      return this.Container.DisposeAsync().AsTask();
    }

    public void Dispose()
    {
      this.configuration.Dispose();
    }
  }
}
