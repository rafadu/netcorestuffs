
namespace AwesomeSauce.Api
{
    public class ComponentA{
        private readonly ComponentB _componentB;
        public ComponentA(){
            this._componentB = new ComponentB();
        }
    }

    public class ComponentB{
        public string Name {get; set;}
        
    }
}