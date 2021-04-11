using playerElement.minor.action;

namespace playerElement.minor
{
    public class Minor : Player
    {
        public int numbStockElement = 10;

        public MinorMovement minorMovement;

        public Minor_Break_Component minorBreakComponent;

        public MinorDisposeObject minorDisposeObject;

        public State_Minor stateMinor = new State_Minor();

        public Minor(){}

        public override BreakComponent BreakComponent()
        {
            return minorBreakComponent;
        }

        public override PlayerMovement PlayerMovement()
        {
            return minorMovement;
        }
        

    }
}
