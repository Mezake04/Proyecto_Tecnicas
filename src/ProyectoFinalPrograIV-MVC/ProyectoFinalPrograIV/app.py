from flask import Flask, render_template

app = Flask(__name__)

# Página principal del portafolio grupal
@app.route("/")
def index():
    return render_template("dashboard.html")  # Se muestra el portafolio estático

# Ruta secundaria si deseas tener una presentación aparte
@app.route("/presentacion")
def presentacion():
    return render_template("login.html")  # Puedes usarla como intro institucional si quieres

if __name__ == "__main__":
    app.run(debug=True)
