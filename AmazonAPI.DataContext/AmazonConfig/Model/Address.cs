/*******************************************************************************
 * Copyright 2009-2018 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License");
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Address
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using AmazonOrderExtentions.CoreExtentions;
using MWSClientCsRuntime;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceWebServiceOrders.Model
{
    [Table("Address", Schema = "amz")]
    public class Address : AbstractMwsObject
    {
        [Key]
        public long Id { set; get; }

        private string _name;
        private string _addressLine1;
        private string _addressLine2;
        private string _addressLine3;
        private string _city;
        private string _country;
        private string _district;
        private string _stateOrRegion;
        private string _municipality;
        private string _postalCode;
        private string _countryCode;
        private string _phone;
        private string _addressType;

        /// <summary>
        /// Gets and sets the Name property.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = EncryptionHelper.Encrypt(value);
            }

            //get { return this._name; }
            //set { this._name = value; }
        }

        /// <summary>
        /// Sets the Name property.
        /// </summary>
        /// <param name="name">Name property.</param>
        /// <returns>this instance.</returns>
        public Address WithName(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// Checks if Name property is set.
        /// </summary>
        /// <returns>true if Name property is set.</returns>
        public bool IsSetName()
        {
            return _name != null;
        }

        /// <summary>
        /// Gets and sets the AddressLine1 property.
        /// </summary>
        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }

        /// <summary>
        /// Sets the AddressLine1 property.
        /// </summary>
        /// <param name="addressLine1">AddressLine1 property.</param>
        /// <returns>this instance.</returns>
        public Address WithAddressLine1(string addressLine1)
        {
            _addressLine1 = addressLine1;
            return this;
        }

        /// <summary>
        /// Checks if AddressLine1 property is set.
        /// </summary>
        /// <returns>true if AddressLine1 property is set.</returns>
        public bool IsSetAddressLine1()
        {
            return _addressLine1 != null;
        }

        /// <summary>
        /// Gets and sets the AddressLine2 property.
        /// </summary>
        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }

        /// <summary>
        /// Sets the AddressLine2 property.
        /// </summary>
        /// <param name="addressLine2">AddressLine2 property.</param>
        /// <returns>this instance.</returns>
        public Address WithAddressLine2(string addressLine2)
        {
            _addressLine2 = addressLine2;
            return this;
        }

        /// <summary>
        /// Checks if AddressLine2 property is set.
        /// </summary>
        /// <returns>true if AddressLine2 property is set.</returns>
        public bool IsSetAddressLine2()
        {
            return _addressLine2 != null;
        }

        /// <summary>
        /// Gets and sets the AddressLine3 property.
        /// </summary>
        public string AddressLine3
        {
            get { return _addressLine3; }
            set { _addressLine3 = value; }
        }

        /// <summary>
        /// Sets the AddressLine3 property.
        /// </summary>
        /// <param name="addressLine3">AddressLine3 property.</param>
        /// <returns>this instance.</returns>
        public Address WithAddressLine3(string addressLine3)
        {
            _addressLine3 = addressLine3;
            return this;
        }

        /// <summary>
        /// Checks if AddressLine3 property is set.
        /// </summary>
        /// <returns>true if AddressLine3 property is set.</returns>
        public bool IsSetAddressLine3()
        {
            return _addressLine3 != null;
        }

        /// <summary>
        /// Gets and sets the City property.
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private DateTime? dateCreated { set; get; }

        //   [AutoMapper.IgnoreMap()]
        public DateTime? CreatedDate
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }

        /// <summary>
        /// Sets the City property.
        /// </summary>
        /// <param name="city">City property.</param>
        /// <returns>this instance.</returns>
        public Address WithCity(string city)
        {
            _city = city;
            return this;
        }

        /// <summary>
        /// Checks if City property is set.
        /// </summary>
        /// <returns>true if City property is set.</returns>
        public bool IsSetCity()
        {
            return _city != null;
        }

        /// <summary>
        /// Gets and sets the County property.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Sets the County property.
        /// </summary>
        /// <param name="county">County property.</param>
        /// <returns>this instance.</returns>
        public Address WithCounty(string county)
        {
            _country = county;
            return this;
        }

        /// <summary>
        /// Checks if County property is set.
        /// </summary>
        /// <returns>true if County property is set.</returns>
        public bool IsSetCounty()
        {
            return _country != null;
        }

        /// <summary>
        /// Gets and sets the District property.
        /// </summary>
        public string District
        {
            get { return _district; }
            set { _district = value; }
        }

        /// <summary>
        /// Sets the District property.
        /// </summary>
        /// <param name="district">District property.</param>
        /// <returns>this instance.</returns>
        public Address WithDistrict(string district)
        {
            _district = district;
            return this;
        }

        /// <summary>
        /// Checks if District property is set.
        /// </summary>
        /// <returns>true if District property is set.</returns>
        public bool IsSetDistrict()
        {
            return _district != null;
        }

        /// <summary>
        /// Gets and sets the StateOrRegion property.
        /// </summary>
        public string StateOrRegion
        {
            get { return _stateOrRegion; }
            set { _stateOrRegion = value; }
        }

        /// <summary>
        /// Sets the StateOrRegion property.
        /// </summary>
        /// <param name="stateOrRegion">StateOrRegion property.</param>
        /// <returns>this instance.</returns>
        public Address WithStateOrRegion(string stateOrRegion)
        {
            _stateOrRegion = stateOrRegion;
            return this;
        }

        /// <summary>
        /// Checks if StateOrRegion property is set.
        /// </summary>
        /// <returns>true if StateOrRegion property is set.</returns>
        public bool IsSetStateOrRegion()
        {
            return _stateOrRegion != null;
        }

        /// <summary>
        /// Gets and sets the Municipality property.
        /// </summary>
        public string Municipality
        {
            get { return _municipality; }
            set { _municipality = value; }
        }

        /// <summary>
        /// Sets the Municipality property.
        /// </summary>
        /// <param name="municipality">Municipality property.</param>
        /// <returns>this instance.</returns>
        public Address WithMunicipality(string municipality)
        {
            _municipality = municipality;
            return this;
        }

        /// <summary>
        /// Checks if Municipality property is set.
        /// </summary>
        /// <returns>true if Municipality property is set.</returns>
        public bool IsSetMunicipality()
        {
            return _municipality != null;
        }

        /// <summary>
        /// Gets and sets the PostalCode property.
        /// </summary>
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        /// <summary>
        /// Sets the PostalCode property.
        /// </summary>
        /// <param name="postalCode">PostalCode property.</param>
        /// <returns>this instance.</returns>
        public Address WithPostalCode(string postalCode)
        {
            _postalCode = postalCode;
            return this;
        }

        /// <summary>
        /// Checks if PostalCode property is set.
        /// </summary>
        /// <returns>true if PostalCode property is set.</returns>
        public bool IsSetPostalCode()
        {
            return _postalCode != null;
        }

        /// <summary>
        /// Gets and sets the CountryCode property.
        /// </summary>
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }

        /// <summary>
        /// Sets the CountryCode property.
        /// </summary>
        /// <param name="countryCode">CountryCode property.</param>
        /// <returns>this instance.</returns>
        public Address WithCountryCode(string countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        /// <summary>
        /// Checks if CountryCode property is set.
        /// </summary>
        /// <returns>true if CountryCode property is set.</returns>
        public bool IsSetCountryCode()
        {
            return _countryCode != null;
        }

        /// <summary>
        /// Gets and sets the Phone property.
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// Sets the Phone property.
        /// </summary>
        /// <param name="phone">Phone property.</param>
        /// <returns>this instance.</returns>
        public Address WithPhone(string phone)
        {
            _phone = phone;
            return this;
        }

        /// <summary>
        /// Checks if Phone property is set.
        /// </summary>
        /// <returns>true if Phone property is set.</returns>
        public bool IsSetPhone()
        {
            return _phone != null;
        }

        /// <summary>
        /// Gets and sets the AddressType property.
        /// </summary>
        public string AddressType
        {
            get { return _addressType; }
            set { _addressType = value; }
        }

        /// <summary>
        /// Sets the AddressType property.
        /// </summary>
        /// <param name="addressType">AddressType property.</param>
        /// <returns>this instance.</returns>
        public Address WithAddressType(string addressType)
        {
            _addressType = addressType;
            return this;
        }

        /// <summary>
        /// Checks if AddressType property is set.
        /// </summary>
        /// <returns>true if AddressType property is set.</returns>
        public bool IsSetAddressType()
        {
            return _addressType != null;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _name = (reader.Read<string>("Name")).Encrypt();
            _addressLine1 = reader.Read<string>("AddressLine1").Encrypt();
            _addressLine2 = reader.Read<string>("AddressLine2").Encrypt();
            _addressLine3 = reader.Read<string>("AddressLine3").Encrypt();
            _city = reader.Read<string>("City").Encrypt();
            _country = reader.Read<string>("Country").Encrypt();
            _district = reader.Read<string>("District").Encrypt();
            _stateOrRegion = reader.Read<string>("StateOrRegion").Encrypt();
            _municipality = reader.Read<string>("Municipality").Encrypt();
            _postalCode = reader.Read<string>("PostalCode").Encrypt();
            _countryCode = reader.Read<string>("CountryCode").Encrypt();
            _phone = reader.Read<string>("Phone").Encrypt();
            _addressType = reader.Read<string>("AddressType").Encrypt();
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("Name", (_name));
            writer.Write("AddressLine1", _addressLine1);
            writer.Write("AddressLine2", _addressLine2);
            writer.Write("AddressLine3", _addressLine3);
            writer.Write("City", _city);
            writer.Write("Country", _country);
            writer.Write("District", _district);
            writer.Write("StateOrRegion", _stateOrRegion);
            writer.Write("Municipality", _municipality);
            writer.Write("PostalCode", _postalCode);
            writer.Write("CountryCode", _countryCode);
            writer.Write("Phone", _phone);
            writer.Write("AddressType", _addressType);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "Address", this);
        }

        public Address(string name) : base()
        {
            _name = name;
        }

        public Address() : base()
        {
        }
    }
}