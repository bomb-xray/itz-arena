using System;
using System.IO;
using System.Text;

namespace BrainwaveEntrainment
{
    class Program
    {
        // ساختار مشخصات حالت مغزی انتخابی
        struct BrainState
        {
            public string Name;          // نام انگلیسی
            public string PersianName;   // نام فارسی
            public double BeatFreq;      // فرکانس ضربان (تفاضل دو گوش)
            public double DefaultCarrier;// فرکانس حامل پیش‌فرض
            public string Description;   // توضیح فارسی اثر
        }

        // ساختار مشخصات فرکانس‌های سولفژیو
        struct Solfeggio
        {
            public double Frequency;
            public string Name;
            public string PersianName;
            public string Benefit;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "BRAINHACK - Terminal Brainwave Entrainment Suite";

            // ۱. تعریف حالت‌های مغزی و امواج ذهنی (اضافه شدن نسخه بهینه ویژه ساندکور به رتبه اول)
            BrainState[] states = new BrainState[]
            {
                new BrainState { Name = "MIND_MELT", PersianName = "🔥 مختل‌کننده ارشد افکار (Mind Melt Extreme - ویژه هندزفری Soundcore R50)", BeatFreq = 4.5, DefaultCarrier = 105.0, Description = "قوی‌ترین فرمول انحلال پچ‌پچ ذهنی؛ طراحی اختصاصی با تلفیق ضربان دوگوشی، پالس ایزوکرونیک، لرزش ساب‌بیس ۵۵ هرتز هماهنگ با درایور ساندکور و نویز قهوه‌ای تعریض‌شده ۳بعدی عریض مستقل." },
                new BrainState { Name = "Delta (Deep Sleep)", PersianName = "موج دلتا (خواب عمیق و بازسازی)", BeatFreq = 1.5, DefaultCarrier = 100.0, Description = "مناسب برای بی‌خوابی، ترمیم فیزیکی بدن، کاهش شدید ترشح کورتیزول و خواب عمیق بدون رویا." },
                new BrainState { Name = "Theta (Deep Trance)", PersianName = "موج تتا (خلسه عمیق، شهود و رویابینی)", BeatFreq = 4.5, DefaultCarrier = 136.1, Description = "فرکانس شمنی؛ عالی برای مدیتیشن عمیق، هیپنوتیزم، دسترسی به ناخودآگاه و سفرهای ذهنی." },
                new BrainState { Name = "Theta (Lucid Dreaming)", PersianName = "موج تتا ۲ (خواب شفاف و خلاقیت)", BeatFreq = 6.0, DefaultCarrier = 144.0, Description = "افزایش یادگیری، تقویت حافظه بلندمدت و افزایش احتمال دیدن خواب‌های شفاف (Lucid Dream)." },
                new BrainState { Name = "Alpha (Flow State)", PersianName = "موج آلفا (وضعیت فلو، یادگیری سریع و تنش‌زدایی)", BeatFreq = 10.0, DefaultCarrier = 432.0, Description = "آرامش هوشیارانه؛ ذوب کردن استرس، مطالعه متمرکز، خلاقیت هنری و کاهش اضطراب فعال." },
                new BrainState { Name = "Beta (Laser Focus)", PersianName = "موج بتا (تمرکز لیزری، منطق و حل مسئله)", BeatFreq = 18.0, DefaultCarrier = 250.0, Description = "حالت بیداری کامل؛ مناسب برای حل مسائل پیچیده ریاضی، برنامه‌نویسی سنگین و تصمیم‌گیری سریع." },
                new BrainState { Name = "Gamma (Cognitive Epiphany)", PersianName = "موج گاما (پردازش برتر و اشراق)", BeatFreq = 40.0, DefaultCarrier = 528.0, Description = "بالاترین سطح هوشیاری؛ یکپارچه‌سازی اطلاعات در مغز، حافظه فوق‌العاده قوی و تجربه‌های اشراقی." }
            };

            // ۲. تعریف فرکانس‌های سولفژیو برای حامل (Carrier)
            Solfeggio[] solfeggios = new Solfeggio[]
            {
                new Solfeggio { Frequency = 174, Name = "174 Hz", PersianName = "فرکانس ۱۷۴ هرتز", Benefit = "کاهش درد فیزیکی و ایجاد احساس امنیت در اندام‌ها" },
                new Solfeggio { Frequency = 285, Name = "285 Hz", PersianName = "فرکانس ۲۸۵ هرتز", Benefit = "کمک به بازسازی بافت‌های آسیب‌دیده و بهبود سلولی" },
                new Solfeggio { Frequency = 396, Name = "396 Hz", PersianName = "فرکانس ۳۹۶ هرتز", Benefit = "رهایی از ترس، گناه، اضطراب‌های پنهان و موانع ذهنی" },
                new Solfeggio { Frequency = 417, Name = "417 Hz", PersianName = "فرکانس ۴۱۷ هرتز", Benefit = "پاکسازی انرژی‌های منفی، تسهیل تغییرات بزرگ و کارما" },
                new Solfeggio { Frequency = 432, Name = "432 Hz", PersianName = "فرکانس ۴۳۲ هرتز", Benefit = "فرکانس هماهنگی با طبیعت، تسکین قلب و آرامش عمیق" },
                new Solfeggio { Frequency = 528, Name = "528 Hz", PersianName = "فرکانس ۵۲۸ هرتز", Benefit = "فرکانس تحول و معجزه، ترمیم DNA و فرکانس عشق جهانی" },
                new Solfeggio { Frequency = 639, Name = "639 Hz", PersianName = "فرکانس ۶۳۹ هرتز", Benefit = "بهبود روابط اجتماعی، همبستگی عاطفی و جذب انرژی مثبت" },
                new Solfeggio { Frequency = 741, Name = "741 Hz", PersianName = "فرکانس ۷۴۱ هرتز", Benefit = "پاکسازی سموم سلولی، بیداری شهود و افزایش قدرت بیان" },
                new Solfeggio { Frequency = 852, Name = "852 Hz", PersianName = "فرکانس ۸۵۲ هرتز", Benefit = "بازگشت به نظم معنوی، از بین بردن توهم و بیداری معنوی" },
                new Solfeggio { Frequency = 963, Name = "963 Hz", PersianName = "فرکانس ۹۶۳ هرتز", Benefit = "چاکرای تاج، اتصال به منبع هستی و بیداری آگاهی برتر خالص" }
            };

            PrintBanner();

            // انتخاب حالت مغزی
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== [ STEP 1: SELECT YOUR TARGET BRAIN STATE / انتخاب حالت مغزی ] ===");
            Console.ResetColor();
            for (int i = 0; i < states.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" [{i + 1}] {states[i].Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" - {states[i].PersianName}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"     └─ Effect: {states[i].Description} (Beat: {states[i].BeatFreq} Hz)");
                Console.ResetColor();
            }

            int stateIndex = GetChoice(1, states.Length) - 1;
            BrainState selectedState = states[stateIndex];

            bool isMindMelt = (selectedState.Name == "MIND_MELT");
            double carrierFreq = selectedState.DefaultCarrier;
            int entrainmentType = 1;
            int ambientChoice = 2;

            if (isMindMelt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🔒 تمامی تنظیمات صوتی به طور خودکار برای هندزفری Soundcore R50 قفل و بهینه‌سازی شدند!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("   ┌─ فرکانس رزونانس ساب‌بیس: 55 هرتز (منطبق با تکنولوژی BassUp ساندکور)");
                Console.WriteLine("   ├─ فرکانس حامل تتا: 105 هرتز (بهینه شده برای مقابله با فشرده‌سازی بلوتوثی SBC/AAC)");
                Console.WriteLine("   ├─ تکنولوژی انتقال: ترکیب دوگوشی + پالس‌های ایزوکرونیک هماهنگ (Hybrid Dual-Entrainment)");
                Console.WriteLine("   └─ فضا‌سازی صوتی: نویز قهوه‌ای عریض ۳بعدی (تولید کانال چپ و راست کاملاً مستقل و استریو)");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                // انتخاب فرکانس حامل (پایه)
                Console.Clear();
                PrintBanner();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== [ STEP 2: SELECT CARRIER FREQUENCY / انتخاب فرکانس پایه (حامل) ] ===");
                Console.ResetColor();
                Console.WriteLine($"حالت انتخابی شما: {selectedState.PersianName} ({selectedState.BeatFreq} Hz)\n");
                Console.WriteLine("انتخاب کنید فرکانس پایه در چه فرکانسی نواخته شود (فرکانس‌های سولفژیو اثرات فرکانسی باستانی دارند):");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" [1] Default Carrier for this state ({selectedState.DefaultCarrier} Hz) - فرکانس پیش‌فرض آرامش‌بخش");
                for (int i = 0; i < solfeggios.Length; i++)
                {
                    Console.WriteLine($" [{i + 2}] {solfeggios[i].PersianName} ({solfeggios[i].Frequency} Hz) - {solfeggios[i].Benefit}");
                }
                Console.WriteLine($" [{solfeggios.Length + 2}] Custom Frequency (ورود فرکانس دلخواه دستی)");
                Console.ResetColor();

                int carrierChoice = GetChoice(1, solfeggios.Length + 2);

                if (carrierChoice == 1)
                {
                    carrierFreq = selectedState.DefaultCarrier;
                }
                else if (carrierChoice == solfeggios.Length + 2)
                {
                    Console.Write("\nوارد کردن فرکانس دلخواه به هرتز (مثلاً 100 تا 500 هرتز پیشنهاد می‌شود): ");
                    while (!double.TryParse(Console.ReadLine(), out carrierFreq) || carrierFreq < 20 || carrierFreq > 2000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("فرکانس نامعتبر! لطفاً عددی بین 20 و 2000 وارد کنید: ");
                        Console.ResetColor();
                    }
                }
                else
                {
                    carrierFreq = solfeggios[carrierChoice - 2].Frequency;
                }

                // انتخاب نوع ضربان و تکنولوژی موج
                Console.Clear();
                PrintBanner();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== [ STEP 3: SELECT ENTRAINMENT METHOD / انتخاب تکنولوژی صوتی ] ===");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" [1] Binaural Beats (ضربان دوگوشی) - *نیاز قطعی به هدفون استریو*");
                Console.WriteLine("     توضیح: فرکانس چپ و راست با هم متفاوت است (مثلاً چپ 200 و راست 210 هرتز). مغز تفاضل این دو (10 هرتز) را درون مغز بازسازی می‌کند.");
                Console.WriteLine(" [2] Monaural Beats (ضربان تک‌گوشی) - *قابل اجرا با هدفون یا بلندگو*");
                Console.WriteLine("     توضیح: هر دو فرکانس در کامپیوتر با هم ترکیب و به هر دو گوش فرستاده می‌شوند. نوسان فیزیکی موج صدا در فضا/بلندگو نیز شنیده می‌شود.");
                Console.WriteLine(" [3] Isochronic Tones (تون‌های ایزوکرونیک) - *قدرتمندترین متد، حتی بدون هدفون*");
                Console.WriteLine("     توضیح: یک تک فرکانس پایه به سرعت و با ریتم فرکانس هدف قطع و وصل (پالس) می‌شود. اثرگذاری بسیار عمیقی روی کورتکس مغز دارد.");
                Console.ResetColor();

                entrainmentType = GetChoice(1, 3);

                // انتخاب لایه پس‌زمینه آمبینت
                Console.Clear();
                PrintBanner();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== [ STEP 4: SELECT BACKGROUND AMBIENT LAYER / انتخاب لایه صوتی پس‌زمینه ] ===");
                Console.ResetColor();
                Console.WriteLine("امواج خالص سینوسی به تنهایی ممکن است خسته‌کننده یا آزاردهنده باشند. یک لایه پس‌زمینه برای عمیق‌تر کردن خلسه انتخاب کنید:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" [1] Pure Waves Only (فقط امواج خالص بدون پس‌زمینه)");
                Console.WriteLine(" [2] Cosmic Space Rumble (غرش عمیق کیهانی - ساب‌بیس 32 هرتز نوسانی بسیار هپنوتیزمی)");
                Console.WriteLine(" [3] Deep Forest Waterfall (باران سنگین و غرش آبشار صوتی - نویز قهوه‌ای بسیار گرم و عمیق)");
                Console.ResetColor();

                ambientChoice = GetChoice(1, 3);
            }

            // انتخاب مدت زمان فایل خروجی
            Console.Clear();
            PrintBanner();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== [ STEP 5: SELECT DURATION / انتخاب مدت زمان ] ===");
            Console.ResetColor();
            Console.Write("مدت زمان فایل خروجی را به دقیقه وارد کنید (مثلاً 5، 15، 30 یا 60 دقیقه): ");
            int durationMinutes;
            while (!int.TryParse(Console.ReadLine(), out durationMinutes) || durationMinutes < 1 || durationMinutes > 180)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("مدت زمان نامعتبر! عددی بین 1 تا 180 دقیقه وارد کنید: ");
                Console.ResetColor();
            }

            // انتخاب نام فایل ذخیره‌سازی
            Console.Write("\nنام فایل ذخیره‌سازی را وارد کنید (یا دکمه Enter را برای نام پیش‌فرض بزنید): ");
            string fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = $"brainhack_{selectedState.Name.Replace(" ", "_").ToLower()}_{durationMinutes}min.wav";
            }
            if (!fileName.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".wav";
            }

            // فرآیند تولید سیگنال صوتی
            Console.Clear();
            PrintBanner();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== [ GENERATING STUDIO QUALITY AUDIO / در حال تولید فایل صوتی استودیویی ] ===");
            Console.ResetColor();
            Console.WriteLine($"► Target State:       {selectedState.Name} ({selectedState.PersianName})");
            Console.WriteLine($"► Beat Frequency:     {selectedState.BeatFreq} Hz");
            Console.WriteLine($"► Carrier Frequency:  {carrierFreq} Hz");
            Console.WriteLine($"► Sound Technology:   {(isMindMelt ? "Hybrid Dual-Entrainment (Soundcore R50 Special)" : (entrainmentType == 1 ? "Binaural Beats" : entrainmentType == 2 ? "Monaural Beats" : "Isochronic Tones"))}");
            Console.WriteLine($"► Ambient Background: {(isMindMelt ? "3D Expanded Brownian Noise & 55Hz Physical Rumble" : (ambientChoice == 1 ? "None" : ambientChoice == 2 ? "Cosmic Space Rumble" : "Deep Forest Waterfall"))}");
            Console.WriteLine($"► Duration:           {durationMinutes} Minute(s) ({durationMinutes * 60} seconds)");
            Console.WriteLine($"► Output Destination: {fileName}");
            Console.WriteLine();

            try
            {
                GenerateWavFile(fileName, carrierFreq, selectedState.BeatFreq, entrainmentType, ambientChoice, durationMinutes, isMindMelt);
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🎉 [SUCCESS / عملیات با موفقیت انجام شد!]");
                Console.ResetColor();
                Console.WriteLine($"فایل صوتی شما با موفقیت ساخته شد و در مسیر زیر ذخیره گردید:\n{Path.GetFullPath(fileName)}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n⚠️ [دستورالعمل مهم برای استفاده روی Soundcore R50]:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ۱. برای این متد، حتماً از هدفون بلوتوثی ساندکور R50 استریو خود استفاده کنید.");
                Console.WriteLine(" ۲. برای همبستگی فرکانس ۵۵ هرتز لرزشی، حتماً مطمئن شوید که اکولایزر هدفون شما روی حالت پیش‌فرض Signature (یا فعال بودن BassUp) در اپلیکیشن Soundcore باشد.");
                Console.WriteLine(" ۳. در یک جای دنج دراز بکشید، چشمان خود را ببندید و صدا را روی ولوم ۵۰ تا ۶۰ درصد (متوسط) قرار دهید.");
                Console.WriteLine(" ۴. توجه هشداری: به هیچ وجه در حین رانندگی یا فعالیت‌های نیازمند هوشیاری از این صدا استفاده نکنید.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nخطا در تولید فایل صوتی: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nبرای خروج از برنامه کلیدی را فشار دهید...");
            Console.ReadKey();
        }

        // رندر و نوشتن مستقیم فرمت صوتی استودیویی WAV
        static void GenerateWavFile(string filePath, double carrier, double beat, int entrainmentType, int ambientType, int durationMinutes, bool isMindMelt)
        {
            int sampleRate = 44100; // کیفیت استاندارد سی‌دی صوتی 44.1kHz
            int durationSeconds = durationMinutes * 60;
            long totalSamples = (long)sampleRate * durationSeconds;

            double fLeft = carrier;
            double fRight = carrier;

            if (entrainmentType == 1 && !isMindMelt) // Binaural: گوش چپ فرکانس پایه، گوش راست تفاضل فرکانس را دریافت می‌کند
            {
                fLeft = carrier - (beat / 2.0);
                fRight = carrier + (beat / 2.0);
            }

            // ولوم اصلی امواج صوتی پایه (بین 0 تا 1)
            double mainVolume = 0.35; 

            // آماده‌سازی بافر نوشتن سریع با فایل باینری
            using (var fs = new FileStream(filePath, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                // ۱. نوشتن هدر استاندارد RIFF WAVE
                bw.Write(Encoding.ASCII.GetBytes("RIFF"));
                bw.Write((int)(36 + totalSamples * 4)); // اندازه کل هدر به علاوه دیتا (کانال استریو ۱۶ بیتی = ۴ بایت برای هر سمپل)
                bw.Write(Encoding.ASCII.GetBytes("WAVE"));

                // ۲. نوشتن اطلاعات فرمت صوتی
                bw.Write(Encoding.ASCII.GetBytes("fmt "));
                bw.Write(16); // طول ساب‌چانک فرمت (۱۶ بایت برای فرمت استاندارد PCM)
                bw.Write((short)1); // فرمت کد ۱ نشان‌دهنده PCM غیرفشرده است
                bw.Write((short)2); // تعداد کانال‌ها: استریو (۲)
                bw.Write(sampleRate); // نرخ نمونه‌برداری (44100)
                bw.Write(sampleRate * 2 * 2); // بایت ریت (ByteRate = SampleRate * NumChannels * BitsPerSample/8)
                bw.Write((short)4); // بلاک اللاین (BlockAlign = NumChannels * BitsPerSample/8)
                bw.Write((short)16); // رزولوشن صوتی ۱۶ بیت

                // ۳. شروع ساب‌چانک داده‌های صوتی
                bw.Write(Encoding.ASCII.GetBytes("data"));
                bw.Write((int)(totalSamples * 4)); // تعداد کل بایت‌های دیتای صوتی

                // نوسان‌سازها و متغیرهای صوتی
                Random rand = new Random();
                double brownLeftState = 0.0;
                double brownRightState = 0.0;

                // متغیرهای نمایش نوار پیشرفت در ترمینال
                long updateInterval = totalSamples / 50; 
                if (updateInterval == 0) updateInterval = 1;

                Console.Write("Progress / پیشرفت: [");
                
                // ۴. حلقه اصلی سنتز و ساخت زنده تک‌تک فریم‌های صوتی
                for (long i = 0; i < totalSamples; i++)
                {
                    double t = (double)i / sampleRate;

                    // الف) موج مغزی پایه بر اساس متد صوتی انتخابی
                    double leftWave = 0;
                    double rightWave = 0;
                    double noiseL = 0.0;
                    double noiseR = 0.0;
                    double rumbleVal = 0.0;

                    if (isMindMelt)
                    {
                        // ۱. فرکانس حامل ۱۰۵ هرتز (عبور کامل از فشرده‌سازی بلوتوثی بدون تحلیل رفتن استریو)
                        double fMeltLeft = 102.75;
                        double fMeltRight = 107.25;

                        // ۲. ضربان دوگوشی پایه
                        double lSine = Math.Sin(2.0 * Math.PI * fMeltLeft * t);
                        double rSine = Math.Sin(2.0 * Math.PI * fMeltRight * t);

                        // ۳. پالس‌های ایزوکرونیک هیبریدی ۴.۵ هرتز (تتا) برای تشدید انحلال افکار
                        double pulseEnvelope = 0.6 + 0.4 * Math.Sin(2.0 * Math.PI * 4.5 * t);
                        leftWave = lSine * pulseEnvelope;
                        rightWave = rSine * pulseEnvelope;

                        // ۴. ساب‌بیس عمیق فیزیکی ۵۵ هرتز (فرکانس تشدید درایورهای ساندکور) با LFO نفس‌زن کُند (۰.۰۵ هرتز)
                        double rumbleLfo = 0.5 + 0.5 * Math.Sin(2.0 * Math.PI * 0.05 * t);
                        rumbleVal = Math.Sin(2.0 * Math.PI * 55.0 * t) * rumbleLfo * 0.28;

                        // ۵. نویز قهوه‌ای عریض سه بعدی مستقل برای کانال چپ و راست
                        double whiteL = rand.NextDouble() * 2.0 - 1.0;
                        double whiteR = rand.NextDouble() * 2.0 - 1.0;
                        brownLeftState = (brownLeftState + (0.02 * whiteL)) / 1.02;
                        brownRightState = (brownRightState + (0.02 * whiteR)) / 1.02;

                        noiseL = brownLeftState * 0.22;
                        noiseR = brownRightState * 0.22;
                    }
                    else
                    {
                        if (entrainmentType == 1) // Binaural Beats
                        {
                            leftWave = Math.Sin(2.0 * Math.PI * fLeft * t);
                            rightWave = Math.Sin(2.0 * Math.PI * fRight * t);
                        }
                        else if (entrainmentType == 2) // Monaural Beats (ترکیب ریاضی دو فرکانس در هر دو کانال)
                        {
                            double monoMix = 0.5 * Math.Sin(2.0 * Math.PI * carrier * t) + 
                                             0.5 * Math.Sin(2.0 * Math.PI * (carrier + beat) * t);
                            leftWave = monoMix;
                            rightWave = monoMix;
                        }
                        else if (entrainmentType == 3) // Isochronic Tones (پالس دامنه با کوسینوس نرم)
                        {
                            double pulseEnvelope = 0.5 + 0.5 * Math.Sin(2.0 * Math.PI * beat * t);
                            double tone = Math.Sin(2.0 * Math.PI * carrier * t);
                            leftWave = tone * pulseEnvelope;
                            rightWave = leftWave;
                        }

                        // ب) تولید لایه‌های پس‌زمینه آمبینت
                        if (ambientType == 2) // Cosmic Space Rumble
                        {
                            double rumbleLfo = 0.4 + 0.3 * Math.Sin(2.0 * Math.PI * 0.1 * t);
                            rumbleVal = Math.Sin(2.0 * Math.PI * 32.0 * t) * rumbleLfo * 0.20;
                        }
                        else if (ambientType == 3) // Deep Forest Waterfall (باران نویز قهوه‌ای)
                        {
                            double white = rand.NextDouble() * 2.0 - 1.0;
                            brownLeftState = (brownLeftState + (0.02 * white)) / 1.02;
                            noiseL = brownLeftState * 0.25;
                            noiseR = noiseL;
                        }
                    }

                    // ج) اعمال فید اوت و فید این (Fade-in/Fade-out) ملایم در ابتدا و انتهای فایل برای ضربه نزدن به مغز و گوش
                    double fadeVolume = 1.0;
                    double fadeDuration = 8.0; // ۸ ثانیه زمان برای فید شدن تدریجی اول و آخر ترک صوتی

                    if (t < fadeDuration)
                    {
                        fadeVolume = t / fadeDuration; // فید این تدریجی از سکوت تا صدای کامل
                    }
                    else if (t > durationSeconds - fadeDuration)
                    {
                        fadeVolume = (durationSeconds - t) / fadeDuration; // فید اوت تدریجی تا سکوت مطلق
                    }

                    if (fadeVolume < 0.0) fadeVolume = 0.0;

                    // د) ترکیب نهایی سیگنال‌ها و اعمال فاکتور فید
                    double finalLeft = (leftWave * mainVolume + noiseL + rumbleVal) * fadeVolume;
                    double finalRight = (rightWave * mainVolume + noiseR + rumbleVal) * fadeVolume;

                    // جلوگیری از اورفلو دیجیتال (Hard Limiter / Clipping prevention)
                    if (finalLeft > 1.0) finalLeft = 1.0;
                    if (finalLeft < -1.0) finalLeft = -1.0;
                    if (finalRight > 1.0) finalRight = 1.0;
                    if (finalRight < -1.0) finalRight = -1.0;

                    // تبدیل مقدار اعشاری (بین ۱- تا ۱) به سمپل صوتی ۱۶ بیتی علامت‌دار (بین ۳۲۷۶۸- تا ۳۲۷۶۷)
                    short sampleL = (short)(finalLeft * 32767);
                    short sampleR = (short)(finalRight * 32767);

                    // نوشتن به فایل WAV در فرمت اینترلیو (اول کانال چپ، بعد کانال راست)
                    bw.Write(sampleL);
                    bw.Write(sampleR);

                    // چاپ نوار پیشرفت در کنسول
                    if (i % updateInterval == 0)
                    {
                        Console.Write("█");
                    }
                }
                Console.WriteLine("] 100% Complete / کامل شد!");
            }
        }

        static int GetChoice(int min, int max)
        {
            int choice;
            Console.Write($"\n👉 Please select an option ({min}-{max}) / انتخاب کنید: ");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"گزینه نامعتبر! عددی بین {min} و {max} وارد کنید: ");
                Console.ResetColor();
            }
            return choice;
        }

        static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
██████╗ ██████╗  █████╗ ██╗███╗   ██╗██╗  ██╗ █████╗  ██████╗██╗  ██╗
██╔══██╗██╔══██╗██╔══██╗██║████╗  ██║██║  ██║██╔══██╗██╔════╝██║ ██╔╝
██████╔╝██████╔╝███████║██║██╔██╗ ██║███████║███████║██║     █████╔╝ 
██╔══██╗██╔══██╗██╔══██║██║██║╚██╗██║██╔══██║██╔══██║██║     ██╔═██╗ 
██████╔╝██║  ██║██║  ██║██║██║ ╚████║██║  ██║██║  ██║╚██████╗██║  ██╗
╚══════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝
                BRAINWAVE ENTRAINMENT & MIND HACKER
");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("=====================================================================");
            Console.WriteLine("     Engineered for Low-Spec Hardware. Pure Digital Mind Alchemy.");
            Console.WriteLine("=====================================================================");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
