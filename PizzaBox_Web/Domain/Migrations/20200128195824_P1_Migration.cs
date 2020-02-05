using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class P1_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pizza_Schema");

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "Pizza_Schema",
                columns: table => new
                {
                    storeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    storeCode = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stores__1EA716331174CC67", x => x.storeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Pizza_Schema",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    userCode = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    storeID = table.Column<int>(nullable: true),
                    storeTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__CB9A1CDF1FD5E7CF", x => x.userID);
                    table.ForeignKey(
                        name: "FK__Users__storeID__19DFD96B",
                        column: x => x.storeID,
                        principalSchema: "Pizza_Schema",
                        principalTable: "Stores",
                        principalColumn: "storeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Pizza_Schema",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeID = table.Column<int>(nullable: false),
                    userID = table.Column<int>(nullable: false),
                    pizzaAmount = table.Column<int>(nullable: false),
                    cost = table.Column<decimal>(type: "money", nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__0809337D22E4B8F6", x => x.orderID);
                    table.ForeignKey(
                        name: "FK__Orders__storeID__1CBC4616",
                        column: x => x.storeID,
                        principalSchema: "Pizza_Schema",
                        principalTable: "Stores",
                        principalColumn: "storeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Orders__userID__1DB06A4F",
                        column: x => x.userID,
                        principalSchema: "Pizza_Schema",
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                schema: "Pizza_Schema",
                columns: table => new
                {
                    pizzaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(nullable: false),
                    crust = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    size = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    pizzaCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pizzas__4D4C90CF900AAF91", x => x.pizzaID);
                    table.ForeignKey(
                        name: "FK__Pizzas__orderID__208CD6FA",
                        column: x => x.orderID,
                        principalSchema: "Pizza_Schema",
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                schema: "Pizza_Schema",
                columns: table => new
                {
                    toppingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizzaID = table.Column<int>(nullable: false),
                    topping = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Toppings__AAE1560922457C0E", x => x.toppingID);
                    table.ForeignKey(
                        name: "FK__Toppings__pizzaI__236943A5",
                        column: x => x.pizzaID,
                        principalSchema: "Pizza_Schema",
                        principalTable: "Pizzas",
                        principalColumn: "pizzaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_storeID",
                schema: "Pizza_Schema",
                table: "Orders",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userID",
                schema: "Pizza_Schema",
                table: "Orders",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_orderID",
                schema: "Pizza_Schema",
                table: "Pizzas",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "UQ__Stores__0E3E451D96309586",
                schema: "Pizza_Schema",
                table: "Stores",
                column: "storeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_pizzaID",
                schema: "Pizza_Schema",
                table: "Toppings",
                column: "pizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_storeID",
                schema: "Pizza_Schema",
                table: "Users",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__66DCF95C7BBEC8C5",
                schema: "Pizza_Schema",
                table: "Users",
                column: "userName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings",
                schema: "Pizza_Schema");

            migrationBuilder.DropTable(
                name: "Pizzas",
                schema: "Pizza_Schema");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Pizza_Schema");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Pizza_Schema");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "Pizza_Schema");
        }
    }
}
