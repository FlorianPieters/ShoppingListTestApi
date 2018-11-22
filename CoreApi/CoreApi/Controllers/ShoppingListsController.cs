﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreApi.Data;
using CoreApi.Entities;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly ShoppingListContext _context;

        public ShoppingListsController(ShoppingListContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public IEnumerable<ShoppingList> GetShoppingList()
        {
            return _context.ShoppingList;
        }

        // GET: api/ShoppingLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingList = await _context.ShoppingList.FindAsync(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        // PUT: api/ShoppingLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingList([FromRoute] int id, [FromBody] ShoppingList shoppingList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingList.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingLists
        [HttpPost]
        public async Task<IActionResult> PostShoppingList([FromBody] ShoppingList shoppingList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShoppingList.Add(shoppingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingList", new { id = shoppingList.Id }, shoppingList);
        }

        // DELETE: api/ShoppingLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingList = await _context.ShoppingList.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingList.Remove(shoppingList);
            await _context.SaveChangesAsync();

            return Ok(shoppingList);
        }

        private bool ShoppingListExists(int id)
        {
            return _context.ShoppingList.Any(e => e.Id == id);
        }
    }
}