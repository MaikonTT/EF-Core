﻿using CursoEFCore.Data;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new Data.ApplicationContext();
            var existe = db.Database.GetPendingMigrations().Any();

            if (existe)
            {
                Console.WriteLine("Existe migrações pendentes!");
            }
            else
            {
                Console.WriteLine("Não existe migrações pendentes!");
            }

            //InserirDados();
            InserirDadosEmMassa();
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 18m,
                Tipo = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new ApplicationContext();
            db.Produtos.Add(produto);

            var registros = db.SaveChanges();

            Console.WriteLine($"Foram afetados: {registros} registro(s)");
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 18m,
                Tipo = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Maikon",
                CEP = "99999000",
                Cidade = "Mogi das Cruzes",
                Estado = "SE",
                Telefone = "99000001111",
            };

            var listaClientes = new[]
            {
                new Cliente
                {
                    Nome = "Maikon2",
                    CEP = "99999000",
                    Cidade = "Mogi das Cruzes",
                    Estado = "SE",
                    Telefone = "99000001111",
                },
                new Cliente
                {
                    Nome = "Maikon3",
                    CEP = "99999000",
                    Cidade = "Mogi das Cruzes",
                    Estado = "SE",
                    Telefone = "99000001111",
                }
        };

            using var db = new ApplicationContext();
            //db.AddRange(produto, cliente);

            db.Clientes.AddRange(listaClientes);

            var registros = db.SaveChanges();

            Console.WriteLine($"Foram afetados: {registros} registro(s)");
        }
    }
}