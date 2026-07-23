#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import os
import sys
import math
import struct
import random
import time

# کدهای رنگی ترمینال برای زیباسازی محیط متنی
class Colors:
    CYAN = '\033[96m'
    YELLOW = '\033[93m'
    GREEN = '\033[92m'
    RED = '\033[91m'
    BOLD = '\033[1m'
    UNDERLINE = '\033[4m'
    GRAY = '\033[90m'
    END = '\033[0m'

# پاک کردن ترمینال بسته به سیستم عامل
def clear_screen():
    os.system('cls' if os.name == 'nt' else 'clear')

# چاپ بنر لوگو به سبک سایبرپانک و متنی هکری
def print_banner():
    print(Colors.CYAN + """
██████╗ ██████╗  █████╗ ██╗███╗   ██╗██╗  ██╗ █████╗  ██████╗██╗  ██╗
██╔══██╗██╔══██╗██╔══██╗██║████╗  ██║██║  ██║██╔══██╗██╔════╝██║ ██╔╝
██████╔╝██████╔╝███████║██║██╔██╗ ██║███████║███████║██║     █████╔╝ 
██╔══██╗██╔══██╗██╔══██║██║██║╚██╗██║██╔══██║██╔══██║██║     ██╔═██╗ 
██████╔╝██║  ██║██║  ██║██║██║ ╚████║██║  ██║██║  ██║╚██████╗██║  ██╗
╚══════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝
                BRAINWAVE ENTRAINMENT & MIND HACKER
""" + Colors.GRAY + """=====================================================================
     Engineered for Low-Spec Hardware. Pure Digital Mind Alchemy.
=====================================================================""" + Colors.END)

def get_choice(min_val, max_val):
    while True:
        try:
            choice = int(input(Colors.CYAN + f"\n👉 Please select an option ({min_val}-{max_val}) / انتخاب کنید: " + Colors.END))
            if min_val <= choice <= max_val:
                return choice
            else:
                print(Colors.RED + f"گزینه نامعتبر! عددی بین {min_val} و {max_val} وارد کنید." + Colors.END)
        except ValueError:
            print(Colors.RED + "ورودی نامعتبر! لطفاً عدد وارد کنید." + Colors.END)

def generate_brain_waves(file_path, carrier, beat, entrainment_type, ambient_type, duration_minutes):
    import wave
    
    sample_rate = 44100  # کیفیت CD صوتی استاندارد
    duration_seconds = duration_minutes * 60
    total_frames = sample_rate * duration_seconds
    
    f_left = carrier
    f_right = carrier
    
    if entrainment_type == 1:  # Binaural Beats
        f_left = carrier - (beat / 2.0)
        f_right = carrier + (beat / 2.0)
        
    main_volume = 0.35
    
    # ساخت فایل WAV برای نوشتن باینری فریم‌ها
    with wave.open(file_path, 'wb') as wav:
        wav.setnchannels(2)      # استریو
        wav.setsampwidth(2)      # ۱۶ بیت (۲ بایت)
        wav.setframerate(sample_rate)
        
        brown_noise_state = 0.0
        
        # مقداردهی به مکانیزم پیشرفت کار
        progress_bar_width = 50
        update_interval = total_frames // progress_bar_width
        if update_interval == 0:
            update_interval = 1
            
        print(Colors.GREEN + "\nProgress / پیشرفت: [" + Colors.END, end="", flush=True)
        
        # بهینه‌سازی سرعت در پایتون: تولید بلاکی نمونه‌ها برای افزایش سرعت فایل‌نویسی
        block_size = 8192
        samples_buffer = []
        
        for i in range(total_frames):
            t = i / sample_rate
            
            left_wave = 0.0
            right_wave = 0.0
            
            # الف) تولید موج مغزی بر اساس متد صوتی
            if entrainment_type == 1:  # Binaural Beats
                left_wave = math.sin(2.0 * math.pi * f_left * t)
                right_wave = math.sin(2.0 * math.pi * f_right * t)
            elif entrainment_type == 2:  # Monaural Beats
                mono_mix = 0.5 * math.sin(2.0 * math.pi * carrier * t) + \
                           0.5 * math.sin(2.0 * math.pi * (carrier + beat) * t)
                left_wave = mono_mix
                right_wave = mono_mix
            elif entrainment_type == 3:  # Isochronic Tones
                pulse_envelope = 0.5 + 0.5 * math.sin(2.0 * math.pi * beat * t)
                tone = math.sin(2.0 * math.pi * carrier * t)
                left_wave = tone * pulse_envelope
                right_wave = left_wave
                
            # ب) شبیه‌سازی سیگنال‌های آمبینت پس‌زمینه
            noise_val = 0.0
            rumble_val = 0.0
            
            if ambient_type == 2:  # Cosmic Space Rumble (غرش بمِ ۳۲ هرتز هوم‌مانند با LFO)
                rumble_lfo = 0.4 + 0.3 * math.sin(2.0 * math.pi * 0.1 * t)
                rumble_val = math.sin(2.0 * math.pi * 32.0 * t) * rumble_lfo * 0.20
            elif ambient_type == 3:  # Deep Forest Waterfall (باران نویز قهوه‌ای عمیق)
                white = random.uniform(-1.0, 1.0)
                brown_noise_state = (brown_noise_state + (0.02 * white)) / 1.02
                noise_val = brown_noise_state * 0.25
                
            # ج) اعمال شیب ولوم ملایم ابتدا و انتها (Fade-in / Fade-out)
            fade_volume = 1.0
            fade_duration = 8.0  # ۸ ثانیه آغاز و پایان فاقد کوبش صوتی
            
            if t < fade_duration:
                fade_volume = t / fade_duration
            elif t > duration_seconds - fade_duration:
                fade_volume = (duration_seconds - t) / fade_duration
                
            if fade_volume < 0.0:
                fade_volume = 0.0
                
            # د) ادغام نهایی کانال‌های صوتی
            final_left = (left_wave * main_volume + noise_val + rumble_val) * fade_volume
            final_right = (right_wave * main_volume + noise_val + rumble_val) * fade_volume
            
            # فیلتر سخت اورفلو (Hard Limiting)
            final_left = max(-1.0, min(1.0, final_left))
            final_right = max(-1.0, min(1.0, final_right))
            
            # نگاشت به اینتجر ۱۶ بیتی علامت‌دار
            sample_l = int(final_left * 32767)
            sample_r = int(final_right * 32767)
            
            samples_buffer.append(sample_l)
            samples_buffer.append(sample_r)
            
            # نوشتن دسته‌ای نمونه‌ها به فایل جهت سرعت بالا
            if len(samples_buffer) >= block_size * 2:
                data_pack = struct.pack(f"<{len(samples_buffer)}h", *samples_buffer)
                wav.writeframesraw(data_pack)
                samples_buffer.clear()
                
            # آپدیت پروگرس بار در خط فرمان
            if i % update_interval == 0:
                print("█", end="", flush=True)
                
        # نوشتن داده‌های باقیمانده در بافر نهایی
        if samples_buffer:
            data_pack = struct.pack(f"<{len(samples_buffer)}h", *samples_buffer)
            wav.writeframesraw(data_pack)
            
        print(Colors.GREEN + "] 100% Complete / کامل شد!" + Colors.END)

def main():
    clear_screen()
    print_banner()
    
    # تعریف پکیج حالات مغزی و اثرات درمانی
    states = [
        {
            "name": "Delta (Deep Sleep)",
            "p_name": "موج دلتا (خواب عمیق و بازسازی)",
            "beat": 1.5,
            "carrier": 100.0,
            "desc": "مناسب برای بی‌خوابی، ترمیم فیزیکی بدن، کاهش شدید ترشح کورتیزول و خواب عمیق بدون رویا."
        },
        {
            "name": "Theta (Deep Trance)",
            "p_name": "موج تتا (خلسه عمیق، شهود و رویابینی)",
            "beat": 4.5,
            "carrier": 136.1,
            "desc": "فرکانس شمنی؛ عالی برای مدیتیشن عمیق، هیپنوتیزم، دسترسی به ناخودآگاه و سفرهای ذهنی."
        },
        {
            "name": "Theta (Lucid Dreaming)",
            "p_name": "موج تتا ۲ (خواب شفاف و خلاقیت)",
            "beat": 6.0,
            "carrier": 144.0,
            "desc": "افزایش یادگیری، تقویت حافظه بلندمدت و افزایش احتمال دیدن خواب‌های شفاف (Lucid Dream)."
        },
        {
            "name": "Alpha (Flow State)",
            "p_name": "موج آلفا (وضعیت فلو، یادگیری سریع و تنش‌زدایی)",
            "beat": 10.0,
            "carrier": 432.0,
            "desc": "آرامش هوشیارانه؛ ذوب کردن استرس، مطالعه متمرکز، خلاقیت هنری و کاهش اضطراب فعال."
        },
        {
            "name": "Beta (Laser Focus)",
            "p_name": "موج بتا (تمرکز لیزری، منطق و حل مسئله)",
            "beat": 18.0,
            "carrier": 250.0,
            "desc": "حالت بیداری کامل؛ مناسب برای حل مسائل پیچیده ریاضی، برنامه‌نویسی سنگین و تصمیم‌گیری سریع."
        },
        {
            "name": "Gamma (Cognitive Epiphany)",
            "p_name": "موج گاما (پردازش برتر و اشراق)",
            "beat": 40.0,
            "carrier": 528.0,
            "desc": "بالاترین سطح هوشیاری؛ یکپارچه‌سازی اطلاعات در مغز، حافظه فوق‌العاده قوی و تجربه‌های اشراقی."
        }
    ]
    
    # فرکانس‌های باستانی سولفژیو برای فرکانس حامل پیشرفته
    solfeggios = [
        {"freq": 174, "p_name": "فرکانس ۱۷۴ هرتز", "benefit": "کاهش درد فیزیکی و ایجاد احساس امنیت در اندام‌ها"},
        {"freq": 285, "p_name": "فرکانس ۲۸۵ هرتز", "benefit": "کمک به بازسازی بافت‌های آسیب‌دیده و بهبود سلولی"},
        {"freq": 396, "p_name": "فرکانس ۳۹۶ هرتز", "benefit": "رهایی از ترس، گناه، اضطراب‌های پنهان و موانع ذهنی"},
        {"freq": 417, "p_name": "فرکانس ۴۱۷ هرتز", "benefit": "پاکسازی انرژی‌های منفی، تسهیل تغییرات بزرگ و کارما"},
        {"freq": 432, "p_name": "فرکانس ۴۳۲ هرتز", "benefit": "فرکانس هماهنگی با طبیعت، تسکین قلب و آرامش عمیق"},
        {"freq": 528, "p_name": "فرکانس ۵۲۸ هرتز", "benefit": "فرکانس تحول و معجزه، ترمیم DNA و فرکانس عشق جهانی"},
        {"freq": 639, "p_name": "فرکانس ۶۳۹ هرتز", "benefit": "بهبود روابط اجتماعی، همبستگی عاطفی و جذب انرژی مثبت"},
        {"freq": 741, "p_name": "فرکانس ۷۴۱ هرتز", "benefit": "پاکسازی سموم سلولی، بیداری شهود و افزایش قدرت بیان"},
        {"freq": 852, "p_name": "فرکانس ۸۵۲ هرتز", "benefit": "بازگشت به نظم معنوی، از بین بردن توهم و بیداری معنوی"},
        {"freq": 963, "p_name": "فرکانس ۹۶۳ هرتز", "benefit": "چاکرای تاج، اتصال به منبع هستی و بیداری آگاهی برتر خالص"}
    ]
    
    # ۱. انتخاب حالت مغزی
    print(Colors.CYAN + "=== [ STEP 1: SELECT YOUR TARGET BRAIN STATE / انتخاب حالت مغزی ] ===" + Colors.END)
    for idx, s in enumerate(states):
        print(Colors.YELLOW + f" [{idx + 1}] {s['name']}" + Colors.END + f" - {s['p_name']}")
        print(Colors.GRAY + f"     └─ Effect: {s['desc']} (Beat: {s['beat']} Hz)" + Colors.END)
        
    state_choice = get_choice(1, len(states)) - 1
    selected_state = states[state_choice]
    
    # ۲. انتخاب فرکانس حامل
    clear_screen()
    print_banner()
    print(Colors.CYAN + "=== [ STEP 2: SELECT CARRIER FREQUENCY / انتخاب فرکانس پایه (حامل) ] ===" + Colors.END)
    print(f"حالت انتخابی شما: {selected_state['p_name']} ({selected_state['beat']} هرتز)\n")
    print("انتخاب کنید فرکانس پایه در چه فرکانسی نواخته شود (فرکانس‌های سولفژیو اثرات فرکانسی باستانی دارند):")
    
    print(Colors.YELLOW + f" [1] Default Carrier for this state ({selected_state['carrier']} Hz) - فرکانس پیش‌فرض آرامش‌بخش" + Colors.END)
    for idx, sol in enumerate(solfeggios):
        print(Colors.YELLOW + f" [{idx + 2}] {sol['p_name']} ({sol['freq']} Hz)" + Colors.END + f" - {sol['benefit']}")
    print(Colors.YELLOW + f" [{len(solfeggios) + 2}] Custom Frequency (ورود فرکانس دلخواه دستی)" + Colors.END)
    
    carrier_choice = get_choice(1, len(solfeggios) + 2)
    
    if carrier_choice == 1:
        carrier_freq = selected_state['carrier']
    elif carrier_choice == len(solfeggios) + 2:
        while True:
            try:
                carrier_freq = float(input("\nوارد کردن فرکانس دلخواه به هرتز (مثلاً 100 تا 500 هرتز پیشنهاد می‌شود): "))
                if 20 <= carrier_freq <= 2000:
                    break
                else:
                    print(Colors.RED + "فرکانس نامعتبر! عددی بین 20 و 2000 وارد کنید." + Colors.END)
            except ValueError:
                print(Colors.RED + "ورودی نامعتبر! لطفاً عدد اعشاری یا صحیح معتبر وارد کنید." + Colors.END)
    else:
        carrier_freq = solfeggios[carrier_choice - 2]['freq']
        
    # ۳. انتخاب تکنولوژی صوتی
    clear_screen()
    print_banner()
    print(Colors.CYAN + "=== [ STEP 3: SELECT ENTRAINMENT METHOD / انتخاب تکنولوژی صوتی ] ===" + Colors.END)
    print(Colors.YELLOW + " [1] Binaural Beats (ضربان دوگوشی) - *نیاز قطعی به هدفون استریو*" + Colors.END)
    print("     توضیح: فرکانس چپ و راست با هم متفاوت است (مثلاً چپ 200 و راست 210 هرتز). مغز تفاضل این دو (10 هرتز) را درون مغز بازسازی می‌کند.")
    print(Colors.YELLOW + " [2] Monaural Beats (ضربان تک‌گوشی) - *قابل اجرا با هدفون یا بلندگو*" + Colors.END)
    print("     توضیح: هر دو فرکانس در کامپیوتر با هم ترکیب و به هر دو گوش فرستاده می‌شوند. نوسان فیزیکی موج صدا در فضا/بلندگو نیز شنیده می‌شود.")
    print(Colors.YELLOW + " [3] Isochronic Tones (تون‌های ایزوکرونیک) - *قدرتمندترین متد، حتی بدون هدفون*" + Colors.END)
    print("     توضیح: یک تک فرکانس پایه به سرعت و با ریتم فرکانس هدف قطع و وصل (پالس) می‌شود. اثرگذاری بسیار عمیقی روی کورتکس مغز دارد.")
    
    entrainment_type = get_choice(1, 3)
    
    # ۴. انتخاب لایه آمبینت پس‌زمینه
    clear_screen()
    print_banner()
    print(Colors.CYAN + "=== [ STEP 4: SELECT BACKGROUND AMBIENT LAYER / انتخاب لایه صوتی پس‌زمینه ] ===" + Colors.END)
    print("امواج خالص سینوسی به تنهایی ممکن است خسته‌کننده یا آزاردهنده باشند. یک لایه پس‌زمینه برای عمیق‌تر کردن خلسه انتخاب کنید:")
    print(Colors.YELLOW + " [1] Pure Waves Only (فقط امواج خالص بدون پس‌زمینه)" + Colors.END)
    print(Colors.YELLOW + " [2] Cosmic Space Rumble (غرش عمیق کیهانی - ساب‌بیس ۳۲ هرتز نوسانی بسیار هپنوتیزمی)" + Colors.END)
    print(Colors.YELLOW + " [3] Deep Forest Waterfall (باران سنگین و غرش آبشار صوتی - نویز قهوه‌ای بسیار گرم و عمیق)" + Colors.END)
    
    ambient_choice = get_choice(1, 3)
    
    # ۵. انتخاب مدت زمان فایل خروجی
    clear_screen()
    print_banner()
    print(Colors.CYAN + "=== [ STEP 5: SELECT DURATION / انتخاب مدت زمان ] ===" + Colors.END)
    while True:
        try:
            duration_minutes = int(input("مدت زمان فایل خروجی را به دقیقه وارد کنید (مثلاً 5، 15، 30 یا 60 دقیقه): "))
            if 1 <= duration_minutes <= 180:
                break
            else:
                print(Colors.RED + "مدت زمان نامعتبر! عددی بین 1 تا 180 دقیقه وارد کنید." + Colors.END)
        except ValueError:
            print(Colors.RED + "ورودی نامعتبر! لطفاً یک عدد صحیح وارد کنید." + Colors.END)
            
    # انتخاب نام فایل
    file_name = input("\nنام فایل ذخیره‌سازی را وارد کنید (یا دکمه Enter را برای نام پیش‌فرض بزنید): ").strip()
    if not file_name:
        sanitized_name = selected_state['name'].replace(" ", "_").lower().replace("(", "").replace(")", "")
        file_name = f"brainhack_{sanitized_name}_{duration_minutes}min.wav"
    if not file_name.lower().endswith('.wav'):
        file_name += '.wav'
        
    # فرآیند سنتز صدا
    clear_screen()
    print_banner()
    print(Colors.GREEN + "=== [ GENERATING STUDIO QUALITY AUDIO / در حال تولید فایل صوتی استودیویی ] ===" + Colors.END)
    print(f"► Target State:       {selected_state['name']} ({selected_state['p_name']})")
    print(f"► Beat Frequency:     {selected_state['beat']} Hz")
    print(f"► Carrier Frequency:  {carrier_freq} Hz")
    print(f"► Sound Technology:   {['Binaural Beats', 'Monaural Beats', 'Isochronic Tones'][entrainment_type-1]}")
    print(f"► Ambient Background: {['None', 'Cosmic Space Rumble', 'Deep Forest Waterfall'][ambient_choice-1]}")
    print(f"► Duration:           {duration_minutes} Minute(s) ({duration_seconds} seconds)")
    print(f"► Output Destination: {file_name}")
    print()
    
    start_time = time.time()
    try:
        generate_brain_waves(file_name, carrier_freq, selected_state['beat'], entrainment_type, ambient_choice, duration_minutes)
        elapsed = time.time() - start_time
        
        print(Colors.GREEN + f"\n🎉 [SUCCESS / عملیات با موفقیت انجام شد!]" + Colors.END)
        print(f"فایل صوتی شما در مدت زمان {elapsed:.2f} ثانیه ساخته شد و در مسیر زیر ذخیره گردید:")
        print(Colors.CYAN + f"👉 {os.path.abspath(file_name)}" + Colors.END)
        
        print(Colors.YELLOW + "\n⚠️ [دستورالعمل مهم برای استفاده]:" + Colors.END)
        print(" ۱. برای امواج دوگوشی (Binaural Beats) استفاده از " + Colors.BOLD + "*هدفون استریو*" + Colors.END + " کاملاً الزامی است.")
        print(" ۲. در یک جای راحت دراز بکشید یا بنشینید، چشمان خود را ببندید و ولوم صدا را روی حالت متوسط (نه خیلی بلند) تنظیم کنید.")
        print(" ۳. " + Colors.RED + "توجه:" + Colors.END + " به هیچ وجه در حین رانندگی، کار با ماشین‌آلات سنگین یا کارهای نیازمند هوشیاری از این فایل صوتی استفاده نکنید.")
        print()
    except Exception as e:
        print(Colors.RED + f"\nخطا در تولید فایل صوتی: {e}" + Colors.END)

if __name__ == "__main__":
    main()
