﻿using Tnf.App.Builder;
using Tnf.Architecture.Domain.WhiteHouse.Specifications;
using Tnf.Architecture.Dto.ValueObjects;

namespace Tnf.Architecture.Domain.WhiteHouse
{
    internal class PresidentBuilder : Builder<President>
    {
        public PresidentBuilder()
            : base()
        {
        }

        public PresidentBuilder(President instance)
            : base(instance)
        {
        }

        public PresidentBuilder WithId(string id)
        {
            Instance.Id = id;
            return this;
        }

        public PresidentBuilder WithName(string name)
        {
            Instance.Name = name;
            return this;
        }

        public PresidentBuilder WithAddress(Address address)
        {
            Instance.Address = address;
            return this;
        }

        public PresidentBuilder WithAddress(string street, string number, string complement, string zipCode)
        {
            Instance.Address = new Address(street, number, complement, new ZipCode(zipCode));
            return this;
        }

        public PresidentBuilder WithAddress(string street, string number, string complement, ZipCode zipCode)
        {
            Instance.Address = new Address(street, number, complement, zipCode);
            return this;
        }

        protected override void Specifications()
        {
            AddSpecification(new PresidentShouldHaveNameSpecification());
            AddSpecification(new PresidentShouldHaveAddressSpecification());
            AddSpecification(new PresidentShouldHaveAddressNumberSpecification());
            AddSpecification(new PresidentShouldHaveAddressComplementSpecification());
            AddSpecification(new PresidentShouldHaveZipCodeSpecification());
        }

        public override President Build()
        {
            base.Validate();
            return base.Build();
        }
    }
}