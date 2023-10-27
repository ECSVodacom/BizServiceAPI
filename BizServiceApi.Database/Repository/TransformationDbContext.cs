using BizServiceApi.Database.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BizServiceApi.Database.Repository
{
    public partial class TransformationDbContext : DbContext
    {
        public TransformationDbContext()
        {
        }

        public TransformationDbContext(DbContextOptions<TransformationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AckermansDataFix> AckermansDataFixes { get; set; } = null!;
        public virtual DbSet<Authenticate> Authenticates { get; set; } = null!;
        public virtual DbSet<BarcodeLookupTable> BarcodeLookupTables { get; set; } = null!;
        public virtual DbSet<CapitecNrt> CapitecNrts { get; set; } = null!;
        public virtual DbSet<DanoneBarcodeDescription> DanoneBarcodeDescriptions { get; set; } = null!;
        public virtual DbSet<DanoneIncorrectBarcode> DanoneIncorrectBarcodes { get; set; } = null!;
        public virtual DbSet<DanoneOrdBarcode> DanoneOrdBarcodes { get; set; } = null!;
        public virtual DbSet<DanoneTaxBarcodeLookup> DanoneTaxBarcodeLookups { get; set; } = null!;
        public virtual DbSet<KwvBatchNumber> KwvBatchNumbers { get; set; } = null!;
        public virtual DbSet<LorealProduct> LorealProducts { get; set; } = null!;
        public virtual DbSet<Marklist> Marklists { get; set; } = null!;
        public virtual DbSet<MiaStoreLookup> MiaStoreLookups { get; set; } = null!;
        public virtual DbSet<MondelezOrderDatum> MondelezOrderData { get; set; } = null!;
        public virtual DbSet<MondelezProdCodeLookup> MondelezProdCodeLookups { get; set; } = null!;
        public virtual DbSet<MondelezProdatBarcode> MondelezProdatBarcodes { get; set; } = null!;
        public virtual DbSet<MondelezQtyLookup> MondelezQtyLookups { get; set; } = null!;
        public virtual DbSet<MondelezShopriteLookup> MondelezShopriteLookups { get; set; } = null!;
        public virtual DbSet<PathReportSequence> PathReportSequences { get; set; } = null!;
        public virtual DbSet<ProcterQty> ProcterQties { get; set; } = null!;
        public virtual DbSet<SaintGobainResponse> SaintGobainResponses { get; set; } = null!;
        public virtual DbSet<AdaptrisOrderHeader> AdaptrisOrderHeaders { get; set; } = null!;
        public virtual DbSet<AdaptrisOrderLine> AdaptrisOrderLines { get; set; } = null!;
        public virtual DbSet<TelkomBarcode> TelkomBarcodes { get; set; } = null!;
        public virtual DbSet<TestDatabase> TestDatabases { get; set; } = null!;
        public virtual DbSet<TestResponseTable> TestResponseTables { get; set; } = null!;
        public virtual DbSet<TestTable> TestTables { get; set; } = null!;
        public virtual DbSet<ThreeGmobileStoreList> ThreeGmobileStoreLists { get; set; } = null!;
        public virtual DbSet<TruworthsBarcodeLookup> TruworthsBarcodeLookups { get; set; } = null!;
        public virtual DbSet<VodaShopOtcCounter> VodaShopOtcCounters { get; set; } = null!;
        public virtual DbSet<VodaTradeCusTable> VodaTradeCusTables { get; set; } = null!;
        public virtual DbSet<VodapayTransaction> VodapayTransactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.101.116;Database=Transformation;User ID=sparuser;Password=ECsqlOnline!; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AckermansDataFix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AckermansDataFix");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Clo)
                    .HasMaxLength(50)
                    .HasColumnName("CLO");

                entity.Property(e => e.Line).HasMaxLength(50);

                entity.Property(e => e.LineNumber).HasColumnName("lineNumber");

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.Qty).HasMaxLength(50);

                entity.Property(e => e.Rsp).HasColumnName("RSP");

                entity.Property(e => e.Sop)
                    .HasMaxLength(50)
                    .HasColumnName("SOP");
            });

            modelBuilder.Entity<Authenticate>(entity =>
            {
                entity.ToTable("Authenticate");

                entity.Property(e => e.Hash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LoginId)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BarcodeLookupTable>(entity =>
            {
                entity.HasKey(e => e.IncorrectBarcode);

                entity.ToTable("BarcodeLookupTable");

                entity.Property(e => e.IncorrectBarcode).HasMaxLength(50);

                entity.Property(e => e.CorrectBarcode).HasMaxLength(50);

                entity.Property(e => e.CorrectProductCode).HasMaxLength(50);

                entity.Property(e => e.Customer).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IncorrectProductCode).HasMaxLength(50);
            });

            modelBuilder.Entity<CapitecNrt>(entity =>
            {
                entity.ToTable("Capitec_NRT");

                entity.Property(e => e.OrignalJson).HasColumnName("OrignalJSON");

                entity.Property(e => e.Received).HasColumnType("datetime");

                entity.Property(e => e.Result)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.SentToBiz).HasColumnType("datetime");
            });

            modelBuilder.Entity<DanoneBarcodeDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DanoneBarcodeDescription");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.BarcodeDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<DanoneIncorrectBarcode>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.BarcodeDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<DanoneOrdBarcode>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CurrentBarcode).HasMaxLength(50);

                entity.Property(e => e.NewBarcode).HasMaxLength(50);
            });

            modelBuilder.Entity<DanoneTaxBarcodeLookup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DanoneTaxBarcodeLookup");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.NewBarcode).HasMaxLength(50);

                entity.Property(e => e.UnitsPer)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<KwvBatchNumber>(entity =>
            {
                entity.ToTable("KWV_BatchNumber");
            });

            modelBuilder.Entity<LorealProduct>(entity =>
            {
                entity.HasKey(e => new { e.Barcode1, e.Barcode2 })
                    .HasName("PK_UserGroup")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Marklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("marklist");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .HasColumnName("number");
            });

            modelBuilder.Entity<MiaStoreLookup>(entity =>
            {
                entity.HasKey(e => e.StoreGln);

                entity.ToTable("MIA_StoreLookup");

                entity.HasIndex(e => e.StoreGln, "IX_MIA_StoreLookup");

                entity.HasIndex(e => e.StoreGln, "IX_MIA_StoreLookup_1");

                entity.Property(e => e.StoreGln)
                    .HasMaxLength(50)
                    .HasColumnName("StoreGLN");

                entity.Property(e => e.StoreCode).HasMaxLength(50);

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MondelezOrderDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerDeliveryPoint).HasMaxLength(50);

                entity.Property(e => e.CustomerOrderNumber).HasMaxLength(50);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.Receiver).HasMaxLength(50);

                entity.Property(e => e.Sender).HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);
            });

            modelBuilder.Entity<MondelezProdCodeLookup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Mondelez_ProdCode_Lookup");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MondelezProdatBarcode>(entity =>
            {
                entity.HasKey(e => e.Barcode);

                entity.ToTable("Mondelez_Prodat_Barcode");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.Qty)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MondelezQtyLookup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Mondelez_qty_Lookup");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MondelezShopriteLookup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MondelezShopriteLookup");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.CustomerGln)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerGLN");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PathReportSequence>(entity =>
            {
                entity.ToTable("PathReportSequence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ReceiverEan)
                    .HasMaxLength(50)
                    .HasColumnName("ReceiverEAN");

                entity.Property(e => e.SenderEan)
                    .HasMaxLength(50)
                    .HasColumnName("SenderEAN");
            });

            modelBuilder.Entity<ProcterQty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Procter_Qty");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SaintGobainResponse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SaintGobainResponse");

                entity.Property(e => e.DeliveryPoint).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");

                entity.Property(e => e.OriginalOrder).HasMaxLength(50);

                entity.Property(e => e.Originator).HasMaxLength(50);

                entity.Property(e => e.Recipient).HasMaxLength(50);

                entity.Property(e => e.ResponseOrder).HasMaxLength(50);
            });

            modelBuilder.Entity<AdaptrisOrderHeader>(entity =>
            {
                entity.ToTable("Adaptris_OrderHeader");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DeliveryPoint)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Receiver)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdaptrisOrderLine>(entity =>
            {
                entity.ToTable("Adaptris_OrderLines");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("money");

                entity.Property(e => e.LineCost).HasColumnType("money");

                entity.Property(e => e.OrderHeaderId).HasColumnName("OrderHeaderID");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderHeader)
                    .WithMany(p => p.AdaptrisOrderLines)
                    .HasForeignKey(d => d.OrderHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adaptris_OrderLines_Adaptris_OrderHeader");
            });

            modelBuilder.Entity<TelkomBarcode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Telkom_Barcodes");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.SupplierCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TestDatabase>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("testDatabase");

                entity.Property(e => e.KeyField)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Receiver)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Testdata)
                    .HasMaxLength(10)
                    .HasColumnName("testdata")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TestResponseTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestResponseTable");

                entity.Property(e => e.Data).HasColumnName("data");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.ToTable("TestTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Test)
                    .HasMaxLength(10)
                    .HasColumnName("test")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ThreeGmobileStoreList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ThreeGMobile_StoreList");

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.StoreEan).HasMaxLength(50);

                entity.Property(e => e.StoreName).HasMaxLength(50);
            });

            modelBuilder.Entity<TruworthsBarcodeLookup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Truworths_Barcode_Lookup");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Supplier).HasMaxLength(50);
            });

            modelBuilder.Entity<VodaShopOtcCounter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Voda_Shop_OTC_Counter");

                entity.Property(e => e.VodaShopOtccounter1).HasColumnName("VodaShopOTCCounter");
            });

            modelBuilder.Entity<VodaTradeCusTable>(entity =>
            {
                entity.ToTable("VodaTrade_Cus_Table");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RetailerEan)
                    .HasMaxLength(50)
                    .HasColumnName("RetailerEAN");

                entity.Property(e => e.RetailerName).HasMaxLength(50);

                entity.Property(e => e.SupplierEan)
                    .HasMaxLength(50)
                    .HasColumnName("SupplierEAN");

                entity.Property(e => e.SupplierName).HasMaxLength(50);
            });

            modelBuilder.Entity<VodapayTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bank).HasMaxLength(50);

                entity.Property(e => e.OriginatorRequestNumber).HasMaxLength(50);

                entity.Property(e => e.Sender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TransactionAmount).HasMaxLength(50);

                entity.Property(e => e.TransactionRecipient).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
