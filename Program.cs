using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecIntf
{
    // The class which implements the contravariant interface
    public class BusinessIdSpecification : ISpecification<BusinessIdSpecification>
    {
        private string businessID;
        private IEnumerable<string> _ReasonsForDissatisfaction = Enumerable.Empty<string>();

        public BusinessIdSpecification(string bID)
        {
            this.businessID = bID; 
        }

        public IEnumerable<string> ReasonsForDissatisfaction
        {
            get
            {
                return _ReasonsForDissatisfaction;
            }
        }

        //The method which tells if the business ID is of correct form
        public bool IsSatisfiedBy(BusinessIdSpecification BIDspec)
        {
           
            if (businessID.Length == 9){ 

                if (businessID.Substring(0,6).All(char.IsDigit)){

                    if (businessID.Contains('-')){

                        if (businessID.EndsWith("1") | businessID.EndsWith("2") | businessID.EndsWith("3") | businessID.EndsWith("4") | businessID.EndsWith("5") | businessID.EndsWith("6") | businessID.EndsWith("7") | businessID.EndsWith("8") | businessID.EndsWith("9") | businessID.EndsWith("0")) 
                        {
                            _ReasonsForDissatisfaction = _ReasonsForDissatisfaction.Concat(new string[] { "Successful business ID! Press any key to continue." });
                            return true;
                        }                        
                        _ReasonsForDissatisfaction = _ReasonsForDissatisfaction.Concat(new string[] { "You entered an incorrect business ID. Please check the following things: \nThe business ID must end with an integer. \n Press any key to continue." });
                        return false;
                    }                    
                    _ReasonsForDissatisfaction = _ReasonsForDissatisfaction.Concat(new string[] { "You entered an incorrect business ID. Please check the following things: \nThe eighth (8.) character of the business ID must be '-'. \nThe business ID must end with an integer. \nPress any key to continue." });
                    return false;
                }                
                _ReasonsForDissatisfaction = _ReasonsForDissatisfaction.Concat(new string[] { "You entered an incorrect business ID. Please check the following things: \nThe first seven (7) characters of the business ID must be integers.  \nThe eighth (8.) character of the business ID must be '-'. \nThe business ID must end with an integer. \nPress any key to continue." });
                return false;
            }
            _ReasonsForDissatisfaction = _ReasonsForDissatisfaction.Concat(new string[] { "You entered an incorrect business ID. Please check the following things: \nThe length of the business ID must be nine (9) characters. \nThe first seven (7) characters of the business ID must be integers. \nThe eighth (8.) character of the business ID must be '-'. \nThe business ID must end with an integer. \nPress any key to continue." });
            
            return false;
            
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a new business ID below.");
            string checkedID = Console.ReadLine();
            // Declaring a class instance "newBIDspec"
            BusinessIdSpecification newBIDspec = new BusinessIdSpecification(checkedID);
            // Declaring an interface instance "newBID"
            ISpecification<BusinessIdSpecification> newBID = newBIDspec;
            // Checking if the business ID is sufficient
            newBID.IsSatisfiedBy(newBIDspec);
            Console.WriteLine(string.Join(",",newBIDspec._ReasonsForDissatisfaction));
            Console.ReadKey();

        }
    }

    //The contravariant interface
    public interface ISpecification<in TEntity>
    {
        IEnumerable<string> ReasonsForDissatisfaction { get; }
        
        bool IsSatisfiedBy(TEntity entity);
    }

    
}
