using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iskambilOyun
{
	public partial class Form1 : Form
	{
		#region Global değişkenler
		ArrayList resimler = new ArrayList();
		ArrayList kartlar = new ArrayList();
		ArrayList etiketler = new ArrayList();
		ArrayList atilan=new ArrayList();
		ArrayList kagitlar = new ArrayList();
		int[] oyunEl = new int[52];
		int deste = 52, el = 13; //elde ve toplam kart
		Label[] lblPuan;
		int acikKartSayisi = 0;
		int[] xx = new int[4];
		int[] yy = new int[4];
		int elSayisi = 0;
		int kacinciKisi = 0;
		int kim=0;
		int saat;
		//int yerde;
		int ihale=4;
		int doner=0;
		int alan;
		bool ciktimi=false;
		giren c=new giren();
		int[] koz=new int[2];
		string attı;
		int gonder=53;
		public struct kisi{
			public int ma;
			public int kar;
			public int sin;
			public int kup;
		};
		public struct giren
		{
			public string koz;
			public int kim;
			public int adet;
		}
		public struct enbuy
		{
			public string tip;
			public int deger;
		}
		giren[] g=new giren[5];
		
		kisi[] oy=new kisi[4];
		enbuy en=new enbuy();
		enbuy ilk=new enbuy();
		#endregion
		#region Form1
		public Form1()
		{
			InitializeComponent();
		}
		#endregion
		#region Form u yukle
		private void Form1_Load(object sender, EventArgs e)
		{
			Random r=new Random();
			kim=r.Next(0,4);
			saat= -1 ;
			resimleriOlustur();
			Dagit_Click(sender, e);
			kartlariSirala();
			ekranaYukle();
			//elPuanları();
			//ayniOlanKartlar();
			//basla();

		}
		#endregion
		#region Yeni oyun Başlat
		private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timer1.Start();
			Temizle();
			resimleriOlustur();
			Dagit_Click(sender, e);
			kartlariSirala();
			ekranaYukle();
			kim ++;
			//   elPuanları();
			//  ayniOlanKartlar();
		}
		#endregion
		#region saat
		public void saatyaz()
		{
			
		}
		#endregion
		#region Ekranı temizle
		private void Temizle()
		{
			ihale=0;
			for (int i = 0; i < deste; i++)
			{
				((PictureBox)kartlar[i]).Dispose();
			}
			saat=-1;
			c=new giren();
			for (int i = 0; i < 8; i++)
			{
				//	((Label)etiketler[i]).Dispose();
			}
			acikKartSayisi = 0;
		}
		#endregion
		#region Kartları Dağıt
		private void Dagit_Click(object sender, EventArgs e)
		{
			
			
			kagitlar.Clear();
			kartlar.Clear();
			etiketler.Clear();
			int x = 575, y = 50, kart = 0, random;
			Random rdn = new Random();
			for (int i = 0; i < 4; i++)
			{
				
				Label lbl = new Label();
				lbl.Name = i.ToString();
				xx[i] = x - 100;
				yy[i] = y + 115;
				lbl.Location = new Point(x - 100, y + 115);
				etiketler.Add(lbl);
				this.Controls.Add(lbl);
				for (int j = 0; j < el; j++)
				{
					PictureBox pcb = new PictureBox();
					pcb.Name = kart.ToString();
					//pcb.Text=kart.ToString();
					pcb.Size = new Size(73, 98);
					pcb.Location = new Point(x, y);
					
					pcb.Click += new EventHandler(pcb_Click);
					pcb.BringToFront();
					x -= 25;

					random = rdn.Next(0, 52);
					while (kagitlar.Contains(random))
						random = rdn.Next(0, 52);
					kagitlar.Add(random);
					kartlar.Add(pcb);
					oyunEl[kart++] = random;
					//pcb.Ima1ge = (Image)resimler[random];
					this.Controls.Add(pcb);
				}
			

				if (i != 1)
					y += 200;//üstteki
				if (i == 1)
					x = 900;//soldaki
				if (i == 2)
					x = 575;//sağdaki
				if (i == 0)
					x = 335;//sağdaki
			}
			
		/*	*/
		}
		#endregion
		#region ne_kartı
		public string karttip(int atilan)//paramtre olarak aldığı numaraya göre kartın tipini dönderir
		{
			string dönder="";
			if(atilan<13&&atilan>=0)
				dönder="sinek";
			else if(atilan<26&&atilan>=13)
				dönder="maca";
			else if(atilan<39&&atilan>=26)
				dönder="kupa";
			else if(atilan<52&&atilan>=39)
				dönder="karo";
			return dönder;
		}
		#endregion
		#region kart_aralıgı
		public bool uyarmı(int p)//atılan kartın atılabilirlik durumunu kontrol eder
		{
			bool r=false;
			
			
			//seriden bir kart atmalısın
			//elinde seri yoksa ve koz varsa kozu geçebilecek koza izin ver(en buyuge ata)
			//geçebilecek yoksa kozlardan herhangi birini atabilirsin
			//elinde kozda yoksa herhangi biri kartı atabilirsin
			if(atilan.Count==0){
				
				if( karttip(oyunEl[p])==c.koz){//eğer atılan ilk kart ise
					if(ciktimi==true){//koz çıktı mı?
						r=true;//çıktıysa koza izin ver
					}//atılan ilk karttın tipni ve değerini tut(en buyuge ata)
					//çıkmadıysa koza izin verme
				}else{//değilse herhangi bir kart ile oyuna giriş yapılabilir
					r=true;//çıktıysa koza izin ver
				}
				ilk.deger=en.deger=oyunEl[p]%13;
				ilk.tip=en.tip=karttip(oyunEl[p]);
				
			}
			else if(atilan.Count!=0)//atılan ilk kart değilse
			{

				if(elseri(p))//yere atılan ilk kart tipinden elinde varsa yerde koz kartından yoksa
				{
					if(!kozyerde())
						r=max(p);
					else if(kozyerde())
						r=eldesuy(p);//elinde yere atılan seride kart varsa
				}
				//elinde yere atılan seride kart varsa
				else	if(eldekoz(p)){//eldeseri yoksa koz var mı
					r=max(p);//koz varsa onu yardır
				}else r=true;
				
			}
			return r;
		}
		#endregion
		#region Kart resimlerini olustur
		void resimleriOlustur()
		{
			Bitmap resim = new Bitmap(1, 1);
			Graphics gr = null;
			//Bu Bitmap için grafik nesnesi oluştur
			int x = 0, y = 0, w = 73, h = 98;
			for (int i = 0; i < 4; i++)
			{
				for (int k = 0; k < 13; k++)
				{
					Rectangle seçili_alan = new Rectangle(x, y, w, h);
					//Seçili alan büyüklüğünde bir Bitmap oluştur
					resim = new Bitmap(seçili_alan.Width, seçili_alan.Height);
					//Bu Bitmap için grafik nesnesi oluştur
					gr = Graphics.FromImage(resim);
					//Picture Box içindeki resmi yeni resmin 0,0 noktasına çiz
					gr.DrawImage(pictureBox1.Image, 0, 0, seçili_alan, GraphicsUnit.Pixel);
					//Yeni resmi pictureBox içine ata
					resimler.Add(resim);
					x += 73;
				}
				y += 98;
				x = 0;
			}
			gr.Dispose();
		}
		#endregion
		#region kozyerdmi
		public bool kozyerde()
		{
			bool y=false;
			for(int i=0;i<atilan.Count;i++)
			{
				if(karttip((int)atilan[i])==c.koz){
					y=true;break;
				}
			}
			return y;
		}
		#endregion
		#region eldesuy
		public bool eldesuy(int i){
			/*parametre olarak aldığı kart numarasına göre eldeseri yada
			 * oyun koz ile başlamasına göre ilgili durumları kontrol eder
			 * */
			bool t=false;
			if(attı==c.koz)//eğer ilk düşülen koz ise
			{
				if(c.koz==karttip(oyunEl[i]))//ve koz atılırsa
				{
					if(buyukvar(i))//atan elemanın tuttuğu kartlarda yerden halihazırda büyükse
					{
						if(oyunEl[i]%13>en.deger)//attığı kart küçükse
						{
							t=true;
							en.deger=oyunEl[i]%13;//en büyüğe ata
						}
					}else
						t=true;//eğer elinde büyük olmayıp koz varsa true
				}
				
			}
			else if(attı==karttip((int)oyunEl[i]))//eğer ilk atılan koz değilse atılan kart tipinden ise true
				t=true;

			return t;
		}
		#endregion
		#region eldeseri
		public bool elseri(int i)//parametre olarak aldığı kart numarasına göre eldeseri olup olmadığını kontrol eder
		{
			bool t=false;
			int[] a=new int[2];
			switch(i/13){
					case 0:a[0]=0; a[1]=13;break;
					case 1:a[0]=13; a[1]=26;break;
					case 2:a[0]=26; a[1]=39;break;
					case 3:a[0]=39; a[1]=52;break;
			}

			for(int j=a[0];j<a[1];j++)
			{
				if(attı==karttip((int)oyunEl[j]))
				{
					t=true;break;
				}
			}
			return t;
		}
		#endregion
		#region eldekoz
		public bool eldekoz(int i)//parametre olarak aldığı kart numarasına göre elde koz olup olmadığını belirtir
		{
			bool t=false;
			int[] a=new int[2];
			switch(i/13){
					case 0:a[0]=0; a[1]=13;break;
					case 1:a[0]=13; a[1]=26;break;
					case 2:a[0]=26; a[1]=39;break;
					case 3:a[0]=39; a[1]=52;break;
			}
			for(int j=a[0];j<a[1];j++)
			{
				if(c.koz==karttip((int)oyunEl[j]))
				{
					t=true;break;
				}
			}
			
			return t;
		}
		
		#endregion
		#region eldebuyukvarmı
		public bool buyukvar(int i)//parametre olarak aldığı kart numarasına göre elinde seriye ait buyuk kart olup olmadığını kontrol eder
		{
			bool t=false;
			int[] a=new int[2];
			switch(i/13){
					case 0:a[0]=0; a[1]=13;break;
					case 1:a[0]=13; a[1]=26;break;
					case 2:a[0]=26; a[1]=39;break;
					case 3:a[0]=39; a[1]=52;break;
			}
			for(int j=a[0];j<a[1];j++)
			{
				if(en.tip==karttip((int)oyunEl[j]) && en.deger<oyunEl[j]%13)
				{
					t=true;break;
				}
			}

			return t;
		}
		#endregion
		#region buyukluk kontrolu
		public bool max(int l)//parametre olarak aldığı
		{
			//yerdeki seriyi geçebilecek kart varmı?
			//varsa onu at(en buyuge ata)
			//yoksa herhangi birini salla
			bool o=false;

			if(attı==karttip(oyunEl[l]))
			{
				if(buyukvar(l))
				{
					if(en.deger<oyunEl[l]%13){
						//	if(c.koz==karttip(oyunEl[l]))ciktimi=true;
						en.deger=oyunEl[l]%13;
						//en.tip=karttip(oyunEl[l]);
						o=true;
					}
					
				}else o=true;//büyük yoksada bu kart tipini al
			}
			
			if(o==false && !elseri(l)){
				if(c.koz==karttip(oyunEl[l]))
				{
					
					if(!buyukvar(l))
					{
						
						en.deger=oyunEl[l]%13;
						en.tip=karttip(oyunEl[l]);
						ciktimi=true;
						o=true;
					}else{
						if(en.deger<oyunEl[l]%13){
							//	if(c.koz==karttip(oyunEl[l]))ciktimi=true;
							en.deger=oyunEl[l]%13;
							en.tip=karttip(oyunEl[l]);
							o=true;
						}//else o=false;
						
						
					}
				}//else if(!(elseri(l)&&eldekoz(l)))o=true;
			}
			return o;
		}
		#endregion
		#region alma_kontrolu
		public int alma()
		{
			int enbuyuk=0;
			int donder=0;
			if(kozyerde())
			{
				for(int i=0;i<4;i++)
				{
					if(c.koz==karttip((int)atilan[i])&& enbuyuk<(int)atilan[i]%13)
					{
						enbuyuk=(int)atilan[i]%13;
						donder=i;
					}
				}
			}
			else{
				for(int i=0;i<4;i++)
				{
					if(attı==karttip((int)atilan[i])&& enbuyuk<(int)atilan[i]%13)
					{
						enbuyuk=(int)atilan[i]%13;
						donder=i;
					}
				}
			}
			return donder;
		}
		#endregion
		#region kapat
		public void kapat()//bu method sıra ile elin döndüğü oyunda sıra kimde ise yalnız onun kartlarının gösterir
		{

			int f;
			int[] a=new int[2];
			if(alan==3)f=2;
			else if(alan==2)f=3;
			else f=alan;
			switch(f)
			{
					case 0:a[0]=0; a[1]=13;break;
					case 1:a[0]=13; a[1]=26;break;
					case 2:a[0]=26; a[1]=39;break;
					case 3:a[0]=39; a[1]=52;break;
			}
			
			foreach (Control c in this.Controls)
			{
				
				if(c is PictureBox && c.Name!="pictureBox1" && c.Name!="150")
				{
					f=int.Parse(((PictureBox)c).Name);
					//MessageBox.Show();
					if(f>= a[0] && f < a[1])
						c.Show();
					else if(f==gonder)
					{
						c.Show();
					}else
						c.Hide();
				}
				
			}
			
		}
		#endregion
		#region Tıklanan kartı ortaya al
		void pcb_Click(object sender, EventArgs e)
		{
			
			if(saat>4)
			{
				int[] aralık=new int[2];
				PictureBox pcb = (PictureBox)sender;
				int deger;
				int kartNo = Convert.ToInt16( pcb.Name);
			//	MessageBox.Show(oyunEl[kartNo].ToString());
				if(alan==2)deger=3;
				else if(alan==3)deger=2;
				
				else deger=alan;
				
				
				if(deger*13<=kartNo && (deger+1)*13>kartNo && uyarmı(kartNo))
				{
					
					//		if(eldekoz((int)oyunEl[kartNo])==true)MessageBox.Show("yerde");

					doner++;
					alan++;
					alan%=4;
					atilan.Add(oyunEl[kartNo]);
					oyunEl[kartNo]=-1;
					if(atilan.Count==1){
						attı=karttip((int)atilan[0]);
					}
					switch(alan)
					{
							case 0:pcb.Location = new Point(490, 250);break;//ortaya kart  atbreak;
							case 1:pcb.Location = new Point(475, 230);break;//ortaya kart  atbreak;
							case 2:pcb.Location = new Point(450, 250);break;//ortaya kart  atbreak;
							case 3:pcb.Location = new Point(475, 280);break;
							default:break;
					}
					
					pcb.BringToFront();
					pcb.Name=gonder.ToString();
					
					
					
					
				}
				if(doner==4){
					doner=0;
					gonder++;
					
					alan=(alan+alma())%4;
					switch(alan)
					{
							case 0:label7.Text=(Convert.ToInt16(label7.Text)+1).ToString();break;
							case 1:label4.Text=(Convert.ToInt16(label4.Text)+1).ToString();break;
							case 2:label5.Text=(Convert.ToInt16(label5.Text)+1).ToString();break;
							case 3:label6.Text=(Convert.ToInt16(label6.Text)+1).ToString();break;
							default:break;
					}
					MessageBox.Show(alan.ToString());
					atilan=new ArrayList();
					attı=null;
					
					
				}
				kapat();
				bittimi();
				

				
				acikKartSayisi--;
				
				
				
				
				
				
				/*	DialogResult c = DialogResult.None;
			if (acikKartSayisi == 0)
				c = MessageBox.Show("Yeni oyun başlasın mı?", "Yeni Oyun", MessageBoxButtons.YesNo);
			if (c == DialogResult.Yes)
				yeniOyunToolS/tripMenuItem_Click(sender, e);
			else if (c == DialogResult.No)
				Close();*/
			}
		}
		#endregion
		#region Kartları Sırala
		void kartlariSirala()
		{
			
			ArrayList oyun = new ArrayList();
			
			for (int i = 0; i  < 4; i++)
			{
				kacinciKisi=i;
				if (i == 2)
					kacinciKisi = 3;
				else if(i == 3 )
					kacinciKisi = 2;
				
				for (int k = 0; k < el; k++)
					oyun.Add(oyunEl[i * el + k]);
				//oyun.Sort();
				ArrayList r=oyun;
				oyun=sirala(r);
				
				for (int k = 0; k < el; k++)
					oyunEl[i * el + k] = int.Parse(oyun[k].ToString());
				oyun.Clear();
				
			}

		}
		#endregion
		#region kart_ayrintili sirala
		public ArrayList sirala(ArrayList ls)
		{
			
			int tane = 0;
			ArrayList re=new ArrayList();
			for(int i=0;i<13;i++)
			{
				if((int)ls[i]>=0 && (int)ls[i]<13)
				{
					re.Add(ls[i]);
					tane ++;
					
				}
			}oy[kacinciKisi].sin=tane;
			tane = 0;
			for(int i=0;i<13;i++)
			{
				if((int)ls[i]>=26 && (int)ls[i]<39)
				{
					re.Add(ls[i]);
					tane ++;
					
				}
			}oy[kacinciKisi].kup=tane;
			
			tane = 0;
			for(int i=0;i<13;i++)
			{
				if((int)ls[i]>=13 && (int)ls[i]<26)
				{
					re.Add(ls[i]);
					tane ++;
					
				}
			}	oy[kacinciKisi].ma=tane;
			tane = 0;
			for(int i=0;i<13;i++)
			{
				if((int)ls[i]>=39 && (int)ls[i]<52)
				{
					re.Add(ls[i]);
					tane ++;
					
				}
			}oy[kacinciKisi].kar=tane;
			
			return re;
		}
		#endregion
		#region Kartları Göster
		void ekranaYukle()
		{
			for (int i = 0; i < deste; i++)
			{
				PictureBox pcb = (PictureBox)kartlar[i];
				pcb.Image = (Image)resimler[oyunEl[i]];
				acikKartSayisi++;
			}
		}
		#endregion
		#region Puanları Hesapla
		private void elPuanları()
		{
			int toplamPuan = 0, kartPuan = 0;

			for (int i = 0; i < 4; i++)
			{
				for (int k = 0; k < el; k++)
				{
					if (oyunEl[i * el + k] % 13 == 0)
						kartPuan = 12;
					else
						if (oyunEl[i * el + k] % 13 == 11)
							kartPuan = 10;
						else
							if (oyunEl[i * el + k] % 13 == 12)
								kartPuan = 11;
							else
								if (oyunEl[i * el + k] % 13 == 10)
									kartPuan = 9;
								else
									if (oyunEl[i * el + k] % 13 == 9)
										kartPuan = 8;
									else
										kartPuan = oyunEl[i * el + k] % 13 + 1;
					toplamPuan += kartPuan;
				}
				Label lbl = (Label)etiketler[i];
				lbl.Text = "Toplam Puan = " + toplamPuan.ToString();
				toplamPuan = 0;
			}
		}
		#endregion
		#region karar
		public giren alacak(kisi r)
		{
			giren g=new giren();
			if(r.kar>=r.sin)
			{
				if(r.kup>=r.kar)
				{
					if(r.ma>=r.kup)
					{
						g.koz="maca";
						g.adet=r.ma;
					}
					else
					{
						g.koz="kupa";
						g.adet=r.kup;
					}
				}else if(r.kar>=r.ma)
				{
					g.koz="karo";
					g.adet=r.kar;
					
				}
				else{
					g.koz="maca";
					g.adet=r.ma;
				}
			}else if(r.sin>=r.kup)
			{
				if(r.sin>=r.ma)
				{
					g.koz="sinek";
					g.adet=r.sin;
				}
				else{
					g.koz="maca";
					g.adet=r.ma;
				}
			}else if(r.kup>=r.ma){
				g.koz="kupa";
				g.adet=r.kup;
			}else {
				g.koz="maca";
				g.adet=r.ma;
			}
			
			return g;
		}
		#endregion
		#region Puanları Hesapla
		private void ayniOlanKartlar()
		{
			string aynısıvar = "";
			int aynı = 1;
			int name = 4;
			for (int j = 0; j < 4; j++)
			{
				string etiket = "";
				aynısıvar = "";
				etiket  +="kar:"+oy[j].kar.ToString()+" kup:"+oy[j].kup.ToString()+" sin:"+oy[j].sin.ToString()+" mac:"+oy[j].ma.ToString();
				Label lblet = new Label();
				lblet.Name = name.ToString();
				lblet.Location = new Point(xx[j], yy[j] + 30);
				lblet.Text = etiket;
				etiketler.Add(lblet);
				this.Controls.Add(lblet);
				name++;
			}
		}
		#endregion
		#region skor göster
		public void skor()
		{
			int[] h=new int[4]{0,0,0,0};
			for(int i=0;i<dataGridView1.RowCount;i++)
			{
				for(int j=0;j<4;j++)
					h[j]+=Convert.ToInt16(dataGridView1.Rows[i].Cells[j].Value);
			}
			MessageBox.Show("0->"+h[0]+"\n1->"+h[1]+"\n2->"+h[2]+"\n3->"+h[3],"zikor");
		}
		#endregion
		private void denemeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<Image> parcaResimler = new List<Image>();
			Bitmap resim;
			Graphics gr = null;
			Image alinanResim = Image.FromFile(@"C:\alinan.jpg");
			int sutunSayisi = 2;
			int satirSayisi = 5;
			int x = 0;
			int y = 0;
			for (int i = 0; i < satirSayisi; i++)
			{
				for (int k = 0; k < sutunSayisi; k++)
				{
					Rectangle seçili_alan = new Rectangle(x, y, alinanResim.Width / sutunSayisi, alinanResim.Height / satirSayisi);
					//Seçili alan büyüklüğünde bir Bitmap oluştur
					resim = new Bitmap(seçili_alan.Width, seçili_alan.Height);
					//Bu Bitmap için grafik nesnesi oluştur
					gr = Graphics.FromImage(resim);
					//Picture Box içindeki resmi yeni resmin 0,0 noktasına çiz
					gr.DrawImage(alinanResim, 0, 0, seçili_alan, GraphicsUnit.Pixel);
					//Yeni resmi parcaResimler içine image olarak kaydet
					parcaResimler.Add(resim);
					x += alinanResim.Width / sutunSayisi;
				}
				y += alinanResim.Height / satirSayisi;
				x = 0;
			}
			gr.Dispose();

			x = 30;
			y = 30;


			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					PictureBox pcb = new PictureBox();
					pcb.Size = new Size(alinanResim.Width / sutunSayisi, alinanResim.Height / satirSayisi);
					pcb.Location = new Point(x, y);
					pcb.Click += new EventHandler(pcb_Click);
					pcb.BringToFront();
					pcb.Image = parcaResimler[i * 5 + j];
					x += 50;
					y += 50;
					this.Controls.Add(pcb);
				}
			}
		}

		
		#region saat
		#region oyun bittimi kontrol
		public void bittimi()
		{
			bool x=false;
			for(int i=0;i<oyunEl.Length;i++)
			{
				if(oyunEl[i]!=-1)
				{
					x=true;break;
				}
			}
			if(x==false){
				
				bul();
				

				label7.Text="0";
				label6.Text="0";
				label5.Text="0";
				label4.Text="0";
			}
			
		}
		#endregion
		#region kisiler
		public void bul()
		{
			int i = dataGridView1.Rows.Add();
			switch(c.kim)
			{
				case 0:
					{
						if(Convert.ToInt16(label7.Text)>=c.adet)
							
							dataGridView1.Rows[i].Cells[0].Value = Convert.ToInt16(label7.Text);
						else
							dataGridView1.Rows[i].Cells[0].Value = "-"+c.adet;
						if(Convert.ToInt16(label4.Text)>0)
							dataGridView1.Rows[i].Cells[1].Value = label4.Text;
						else
							dataGridView1.Rows[i].Cells[1].Value = "-"+c.adet;
						if(Convert.ToInt16(label5.Text)>0)
							dataGridView1.Rows[i].Cells[2].Value = label5.Text;
						else
							dataGridView1.Rows[i].Cells[2].Value = "-"+c.adet;
						if(Convert.ToInt16(label6.Text)>0)
							dataGridView1.Rows[i].Cells[3].Value = label6.Text;
						else
							dataGridView1.Rows[i].Cells[3].Value = "-"+c.adet;
					}break;
				case 1:
					{
						if(Convert.ToInt16(label4.Text)>=c.adet)
							dataGridView1.Rows[i].Cells[1].Value = Convert.ToInt16(label4.Text);
						else
							dataGridView1.Rows[i].Cells[1].Value = "-"+c.adet;
						if(Convert.ToInt16(label7.Text)>0)
							dataGridView1.Rows[i].Cells[0].Value = label7.Text;
						else
							dataGridView1.Rows[i].Cells[0].Value = "-"+c.adet;
						if(Convert.ToInt16(label5.Text)>0)
							dataGridView1.Rows[i].Cells[2].Value = label5.Text;
						else
							dataGridView1.Rows[i].Cells[2].Value = "-"+c.adet;
						if(Convert.ToInt16(label6.Text)>0)
							dataGridView1.Rows[i].Cells[3].Value = label6.Text;
						else
							
							dataGridView1.Rows[i].Cells[3].Value ="-"+c.adet;
					}break;
				case 2:
					{
						if(Convert.ToInt16(label5.Text)>=c.adet)
							dataGridView1.Rows[i].Cells[2].Value = Convert.ToInt16(label5.Text);
						else
							dataGridView1.Rows[i].Cells[2].Value = "-"+c.adet;
						if(Convert.ToInt16(label4.Text)>0)
							dataGridView1.Rows[i].Cells[1].Value = label4.Text;
						else
							dataGridView1.Rows[i].Cells[1].Value = "-"+c.adet;
						if(Convert.ToInt16(label7.Text)>0)
							dataGridView1.Rows[i].Cells[0].Value = label7.Text;
						else
							dataGridView1.Rows[i].Cells[0].Value = "-"+c.adet;
						if(Convert.ToInt16(label6.Text)>0)
							dataGridView1.Rows[i].Cells[3].Value = label6.Text;
						else
							dataGridView1.Rows[i].Cells[3].Value = "-"+c.adet;
						
						
						
						
					}break;
					
				case 3:
					{
						if(Convert.ToInt16(label6.Text)>=c.adet)
							dataGridView1.Rows[i].Cells[3].Value = c.adet;
						else
							dataGridView1.Rows[i].Cells[3].Value = "-"+c.adet;
						
						if(Convert.ToInt16(label4.Text)>0)
							dataGridView1.Rows[i].Cells[1].Value = label4.Text;
						else
							dataGridView1.Rows[i].Cells[1].Value = "-"+c.adet;
						if(Convert.ToInt16(label5.Text)>0)
							dataGridView1.Rows[i].Cells[2].Value = label5.Text;
						else
							dataGridView1.Rows[i].Cells[2].Value = "-"+c.adet;
						if(Convert.ToInt16(label7.Text)>0)
							dataGridView1.Rows[i].Cells[0].Value = label7.Text;
						else
							dataGridView1.Rows[i].Cells[0].Value = "-"+c.adet;
						
						
						
						
					}break;
					default:break;
					
			}
		}
		
		#endregion
		void Timer1Tick(object sender, EventArgs e)
		{
			label3.Text="seri: "+en.tip+" deger:"+en.deger;
			saat++;
			label1.Text=saat/3600+" saat"+(saat%3600)/60+" dk"+saat%60+" sn";
			giren m=new giren();
			
			if(saat%4==0)
			{
				m=g[0]=alacak(oy[kim%4]);
				m.kim=g[0].kim=kim%4;
				
			}else if(saat%4==1)
			{
				m=g[1]=alacak(oy[(kim+1)%4]);
				m.kim=g[1].kim=(kim+1)%4;
			}else if(saat%4==2)
			{
				m=g[2]=alacak(oy[(kim+2)%4]);
				m.kim=g[2].kim=(kim+2)%4;
			}
			else if(saat%4==3)
			{
				m=g[3]=alacak(oy[(kim+3)%4]);
				m.kim=g[3].kim=(kim+3)%4;
			}
			if(saat<4 )
			{
				if( m.adet>ihale){
					label2.Text=m.kim.ToString()+" "+m.adet.ToString();
					ihale=m.adet;
					c=m;
				}else if(ihale>=m.adet){
					label2.Text=m.kim.ToString()+" pas";
				}
				
			}
			else if(saat==4 && ihale<5 )
			{
				label2.Text=g[0].adet.ToString();c=g[0];
			}
			if(saat==5){
				label2.Text=c.kim.ToString()+" "+c.adet.ToString()+" tip:"+c.koz;
				MessageBox.Show("Oyuna giren : "+c.kim+",Koz :  "+c.koz+",c.adet :  "+c.adet.ToString());
				
				alan=c.kim;
				kapat();
				if(c.koz=="maca")
				{
					koz[0]=13;
					koz[1]=26;
				}else if(c.koz=="kupa"){
					koz[0]=26;
					koz[1]=39;
				}else if(c.koz=="karo"){
					koz[0]=39;
					koz[1]=52;
				}else if(c.koz=="sinek"){
					koz[0]=0;
					koz[1]=13;
				}
			}
			
			
			
		}
		#endregion
        
        void Button1Click(object sender, EventArgs e)
        {
        	skor();
        }
	}
}
