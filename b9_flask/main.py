from flask import Flask

app = Flask(__name__)

# декоратор позволяет запустить страницу, на которой мы находимся
@app.route('/') # если пользователь заходит на главную страницу
def main (): # запускаем эту функцию
    return "<h1>Hello, world</h1><br><a href = '/index'>перейти на 2-ю страницу</a>"

# декоратор вызывает функцию
@app.route('/index/<x>/<y>')
def index(x, y): # передача аргументов через адресную строку
    return f'Результат: {int(x) + int(y)}'


if __name__ == '__main__':
    app.run()