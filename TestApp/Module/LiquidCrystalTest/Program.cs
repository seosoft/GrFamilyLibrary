using System.Threading;
using GrFamily.MainBoard;
using GrFamily.Module;

namespace LiquidCrystalTest
{
    public class Program
    {
        public static void Main()
        {
            Thread.Sleep(1000);

            // 開発時の標準ピンアサイン
            var lcd = new LiquidCrystal(Pins.GPIO_PIN_D9, Pins.GPIO_PIN_D8,
                Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D6, Pins.GPIO_PIN_D5, Pins.GPIO_PIN_D4);
            // ピン変更テスト
            //var lcd = new LiquidCrystal(Pins.GPIO_PIN_D9, Pins.GPIO_PIN_D8,
            //    Pins.GPIO_PIN_D3, Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D1, Pins.GPIO_PIN_D0);

            // GR-PEACHではコマンド間のウェイトなし動作する（ウェイトありでも問題ない）
            // GR -SAKURAではウェイトを入れないと誤動作する
            lcd.InitDevice();

            var runner = new LcdTestRunner(lcd);
            runner.Run();
        }
    }
}
