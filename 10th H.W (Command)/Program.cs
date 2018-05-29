using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_Command
{
    class Program
    {
        /*Hu's Command Program 입니다. 주석이 달려있는 메서드들은 Tab을 눌렀을때 자동완성 기능을 추가 하고싶어서 진행하는
         * 도중 시간이 부족해서 구현을 완벽하게 하지 못해서 기존의 방식대로 해놓았고, 나중에 꼭 구현해보고 싶은 오기가
         * 생겨서 지우지 않았는데 보기 번거롭게 해드린 점 양해 부탁드립니다.
         * 
         * 기능은 cls , help , cd , dir , copy , move 가 있으며
         * windows에 있는 cmd 창과 동일하게 만들기 위해 노력을 기울였습니다.
         *
         *클래스 구조                
         *                          
         * Program -> StartCommand ->Operations
         *                       
         *                       Print,constants (모든 곳에서 호출)                        
         */
        static void Main(string[] args)
        {
            StartCommand start = new StartCommand();
            start.Waiting();
        }
    }
}
