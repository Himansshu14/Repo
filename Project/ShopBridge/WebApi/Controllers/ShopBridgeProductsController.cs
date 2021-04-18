using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ShopBridgeProductsController : ApiController
    {
        private ShopBridgeDatabaseEntities db = new ShopBridgeDatabaseEntities();

        // GET: api/ShopBridgeProducts
        public IQueryable<ShopBridgeProduct> GetShopBridgeProducts()
        {
            return db.ShopBridgeProducts;
        }

        // GET: api/ShopBridgeProducts/5
        [ResponseType(typeof(ShopBridgeProduct))]
        public async Task<IHttpActionResult> GetShopBridgeProduct(int id)
        {
            ShopBridgeProduct shopBridgeProduct = await db.ShopBridgeProducts.FindAsync(id);
            if (shopBridgeProduct == null)
            {
                return NotFound();
            }

            return Ok(shopBridgeProduct);
        }

        // PUT: api/ShopBridgeProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShopBridgeProduct(int id, ShopBridgeProduct shopBridgeProduct)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != shopBridgeProduct.ProductId)
            {
                return BadRequest();
            }

            db.Entry(shopBridgeProduct).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopBridgeProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ShopBridgeProducts
        [ResponseType(typeof(ShopBridgeProduct))]
        public async Task<IHttpActionResult> PostShopBridgeProduct(ShopBridgeProduct shopBridgeProduct)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.ShopBridgeProducts.Add(shopBridgeProduct);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shopBridgeProduct.ProductId }, shopBridgeProduct);
        }

        // DELETE: api/ShopBridgeProducts/5
        [ResponseType(typeof(ShopBridgeProduct))]
        public async Task<IHttpActionResult> DeleteShopBridgeProduct(int id)
        {
            ShopBridgeProduct shopBridgeProduct = await db.ShopBridgeProducts.FindAsync(id);
            if (shopBridgeProduct == null)
            {
                return NotFound();
            }

            db.ShopBridgeProducts.Remove(shopBridgeProduct);
            await db.SaveChangesAsync();

            return Ok(shopBridgeProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopBridgeProductExists(int id)
        {
            return db.ShopBridgeProducts.Count(e => e.ProductId == id) > 0;
        }
    }
}