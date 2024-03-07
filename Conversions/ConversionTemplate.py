# Title: ConversionTemplate.py
# History: 
#   03/07/24 - Created
# Purpose: Template for running conversions on the database
import sqlite3
import json

# Conversion ID
convId = 'MyFirstConversion!'

# Set up SQL connection and cursor
f = open('appsettings.json')
data = json.load(f)
dbname = data['ConnectionStrings']['MvcCocktailContext'].partition('=')[2]
con = sqlite3.connect(dbname)
cur = con.cursor()

# Check if conversion is new or already ran
query = 'CREATE TABLE IF NOT EXISTS ConversionLog ( ConversionId varchar(255) NOT NULL );'
cur.execute(query)
query = f'SELECT 1 FROM ConversionLog WHERE ConversionId = "{convId}";'
cur.execute(query)
newConv = cur.fetchone() is None

if newConv:
  # Insert conversion code here
  query = 'SELECT * FROM Cocktails'
  cur.execute(query)
  print(cur.fetchall())

  # Register conversion in ConversionLog
  query = f'INSERT INTO ConversionLog VALUES ("{convId}");'
  cur.execute(query)
  con.commit()
else:
  print(f"Conversion '{convId}' already ran on this database.")
