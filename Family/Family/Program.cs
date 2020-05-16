using System;

namespace Family
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("我肚子餓了，好想吃東西，要吃甚麼呢?");
            Console.WriteLine("選擇餐廳類型 1:鼎泰豐 2:一蘭拉麵 3:孫東寶");
            int 餐廳類型 = Convert.ToInt32(Console.ReadLine());
            吃飯 eat = new 吃飯();
            餐廳 rest = eat.選擇餐廳(餐廳類型);
            Console.WriteLine("我選擇的餐廳是:" + rest.name);
            eat.去餐廳(rest);
            Console.WriteLine("歡迎光臨"+rest.name+"，請問您要吃甚麼呢?:");
            string meal = Console.ReadLine();
            菜單 menu = new 菜單();
            menu.selected = meal;
            eat.點餐(menu);
            Console.WriteLine("好的，請您稍微等待幾分鐘，我們馬上為您上菜:");
            eat.等待(5);
            eat.吃();
            Console.WriteLine("服務生，我要結帳了，請問多少錢? 300  元");
            int payMoney = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("您要用甚麼方式支付呢? 現金，Apple pay, Line Pay, Send 3 Pay");
            string payType = Console.ReadLine();
            eat.付錢(payMoney, payType);
            Console.WriteLine("謝謝光臨，歡迎下次再來唷!");
            eat.離開();



        }
    }
}
