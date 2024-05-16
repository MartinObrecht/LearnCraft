using System.Diagnostics.CodeAnalysis;
using LearnCraft.Api.Controllers;
using LearnCraft.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LearnCraft.Api.Tests;

[ExcludeFromCodeCoverage]
public class CachorrosControllerTest
{
    [Fact]
    [Trait("Read", "API")]
    public async Task GetAsync_ReturnOk()
    {
        //Arrange
        var cachorro = new Domain.Cachorro { Nome = "Manoel", Nascimento = DateTime.Now, Adotado = false, Peso = 10, Pelagem = Domain.Pelagem.Curto };

        var options = new DbContextOptionsBuilder<CachorroContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using (var context = new CachorroContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Cachorros.Add(cachorro);
            context.SaveChanges();
        }

        using (var context = new CachorroContext(options))
        {
            var controller = new CachorrosController(context);

            //Act
            var result = await controller.GetAsync();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Domain.Cachorro>>(okResult.Value);
            Assert.Single(model);
        }
    }

    [Fact]
    [Trait("Read", "API")]
    public async Task GetByIdAsync_ReturnOk()
    {
        //Arrange
        var cachorro = new Domain.Cachorro { Nome = "Manoel", Nascimento = DateTime.Now, Adotado = false, Peso = 10, Pelagem = Domain.Pelagem.Curto };

        var options = new DbContextOptionsBuilder<CachorroContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using (var context = new CachorroContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Cachorros.Add(cachorro);
            context.SaveChanges();
        }

        using (var context = new CachorroContext(options))
        {
            var controller = new CachorrosController(context);

            //Act
            var result = await controller.GetByIdAsync(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Domain.Cachorro>(okResult.Value);
            Assert.Equal(cachorro.Nome, model.Nome);
        }
    }

    [Fact]
    [Trait("Create", "API")]
    public async Task PostAsync_ReturnCreated()
    {
        //Arrange
        var cachorro = new Domain.Cachorro { Nome = "Manoel", Nascimento = DateTime.Now, Adotado = false, Peso = 10, Pelagem = Domain.Pelagem.Curto };

        var options = new DbContextOptionsBuilder<CachorroContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using (var context = new CachorroContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        using (var context = new CachorroContext(options))
        {
            var controller = new CachorrosController(context);

            //Act
            var result = await controller.PostAsync(cachorro);

            //Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsAssignableFrom<Domain.Cachorro>(createdResult.Value);
            Assert.Equal(cachorro.Nome, model.Nome);
        }
    }

    [Fact]
    [Trait("Delete", "API")]
    public async Task DeleteAsync_ReturnNoContent()
    {
        //Arrange
        var cachorro = new Domain.Cachorro { Nome = "Manoel", Nascimento = DateTime.Now, Adotado = false, Peso = 10, Pelagem = Domain.Pelagem.Curto };

        var options = new DbContextOptionsBuilder<CachorroContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using (var context = new CachorroContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Cachorros.Add(cachorro);
            context.SaveChanges();
        }

        using (var context = new CachorroContext(options))
        {
            var controller = new CachorrosController(context);

            //Act
            var result = await controller.DeleteAsync(1);

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }
    }
}