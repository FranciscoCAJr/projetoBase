using FluentAssertions;
using HelperStockBeta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Domain.Test
{
    #region Casos de testes positivos
    public class CategoryUnitTestBase
    {
        [Fact(DisplayName ="Category name is not null")]
        public void CreateCategory_WithValidParemeters_ResultValid()
        {
            Action action = () => new Category(1, "Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Category no present id parameter.")]
        public void CreateCategory_IdParameterLess_ResultValid()
        {
            Action action = () => new Category("Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        [Fact(DisplayName="Category name not null")]
        public void CreateProduct_withParameters_ResultValid()
        {
            Action action = () => new Category(1, "Category test");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Category no present id parameter")]
        public void CreateProduct_withParameters_ResultValid()
        {
            Action action = () => new Category("Category test");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Casos de testes negativos
        [Fact(DisplayName = "Id negative exception.")]
        public void CreateCategory_NegativeParameterId_ResultException()
        {
            Action action = () => new Category(-1, "Categoria Teste");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Identification is positive values!");
        }
        [Fact(DisplayName = "Name in Category null.")]
        public void CreateCategory_NameParameterNull_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }
        [Fact(DisplayName = "Name short for Category null.")]
        public void CreateCategory_NameParameterShort_ResultException()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is minimum 3 charecters");
        }
        #endregion
        [Fact(DisplayName = "id negative exception")]
        public void CreateProduct_withParameters_ResultValid()
        {
            Action action = () => new Product(-1, "Category test");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("invalid id, Id cannot be negative");
        }
        [Fact(DisplayName = "Category name null exception")]
        public void CreateProduct_withParameters_ResultValid()
        {
            Action action = () => new Product(1, null);
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name cannot be blank");
        }
        [Fact(DisplayName = "short category name exception")]
        public void CreateProduct_withParameters_ResultValid()
        {
            Action action = () => new Product(1, "ca");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("invalid name, name needs at least 3 characters");
        }
    }
}