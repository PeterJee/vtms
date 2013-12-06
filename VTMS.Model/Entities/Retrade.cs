using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model.Entities
{
    public class Retrade
    {
        #region Private Members

        // Primary Key(s) 
        private string serial;

        // Properties 
        private string reserial;
        private Customer originCustomer;
        private byte[] originpic;
        private Customer currentCustomer;
        private byte[] currentpic;
        private string invoice;
        private string license;
        private string vin;
        private Vehicletype vehicletype;
        private string brand;
        private string certificate;
        private string register;
        private string certification;
        private string department;
        private Company company;
        private Users saver;
        private DateTime savedate;
        private byte[] firstpic;
        private byte[] secondpic;
        private byte[] thirdpic;
        private byte[] forthpic;
        private bool istraded;

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Serial
        {
            get { return serial; }
            set
            {
                serial = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Reserial
        {
            get { return reserial; }
            set
            {
                reserial = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Customer OriginCustomer
        {
            get { return originCustomer; }
            set
            {
                originCustomer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Originpic
        {
            get { return originpic; }
            set
            {
                originpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set
            {
                currentCustomer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Currentpic
        {
            get { return currentpic; }
            set
            {
                currentpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Invoice
        {
            get { return invoice; }
            set
            {
                invoice = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string License
        {
            get { return license; }
            set
            {
                license = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Vin
        {
            get { return vin; }
            set
            {
                vin = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Vehicletype Vehicletype
        {
            get { return vehicletype; }
            set
            {
                vehicletype = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Certificate
        {
            get { return certificate; }
            set
            {
                certificate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Register
        {
            get { return register; }
            set
            {
                register = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Certification
        {
            get { return certification; }
            set
            {
                certification = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string Department
        {
            get { return department; }
            set
            {
                department = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Company Company
        {
            get { return company; }
            set
            {
                company = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual Users Saver
        {
            get { return saver; }
            set
            {
                saver = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual DateTime SaveDate
        {
            get { return savedate; }
            set { savedate = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Firstpic
        {
            get { return firstpic; }
            set
            {
                firstpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Secondpic
        {
            get { return secondpic; }
            set
            {
                secondpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Thirdpic
        {
            get { return thirdpic; }
            set
            {
                thirdpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual byte[] Forthpic
        {
            get { return forthpic; }
            set
            {
                forthpic = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual bool Istraded
        {
            get { return istraded; }
            set
            {
                istraded = value;
            }

        }
        #endregion
    }
}
