using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Family
{
   public class 吃飯 { 


        public 餐廳 選擇餐廳(int 餐飲類別) {
            餐廳 _rest = new 餐廳();
            switch (餐飲類別) {
                case 1:
                    _rest = new 鼎泰豐();                   
                    break;
                case 2:
                    _rest = new 一蘭();
                    break;
                case 3:
                    _rest = new 孫東寶();
                    break;
                default:
                    _rest = new 一蘭();
                    break;
            }
            return _rest;
        }
        public void 去餐廳(餐廳 rest) {
            //go().....
            Console.WriteLine("餐廳 店名:"+ rest.name + "地址是: " + rest.address);
        }
        public void 點餐(菜單 menu) {
            Console.WriteLine("我要吃:" + menu.selected);
        }
        public void 等待(int 分鐘) {
            //Thread.Sleep(5 * 1000);
            Console.WriteLine("要等幾分鐘 "+分鐘);
        }

        public void 吃() {
            Console.WriteLine("開動");
        }
        public void 付錢(int money,string payType) {

            Console.WriteLine("結帳要負多少錢["+money+"]用甚麼付錢["+payType+"]");
        }
        public void 離開() {
            Console.WriteLine("我吃飽了，閃人");
        }
    }
}
