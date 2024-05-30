""" permite distintos tipos de interpolacion y tiene un boton 
llmado interpolar para actualizar los datos del cuadro"""
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
import tkinter as tk
from tkinter import filedialog, messagebox, simpledialog
from pandastable import Table

class DataAnalyzerApp:
    def __init__(self, master):
        self.master = master
        master.title("Data Analyzer")
        master.geometry('400x400+400+100')

        # Título principal
        self.title_label = tk.Label(master, text="Análisis de Datos", font=("Arial", 16, "bold"))
        self.title_label.pack(pady=10)

        # Frame principal para organizar los elementos
        self.main_frame = tk.Frame(master)
        self.main_frame.pack(fill=tk.BOTH, expand=True)

        # Botón para cargar archivo
        self.btn_cargar = tk.Button(self.main_frame, text="Cargar Archivo", command=self.cargar_archivo, bg="red", fg="white", font=("Arial", 12))
        self.btn_cargar.pack(pady=10)

        # Frame para mostrar la tabla
        self.info_frame = tk.Frame(self.main_frame)
        self.info_frame.pack(fill=tk.BOTH, expand=True)

        # Frame para las opciones de interpolación
        self.interpolation_frame = tk.Frame(self.main_frame)
        self.interpolation_frame.pack(pady=10)

        # Selector de tipo de interpolación
        self.interpolation_label = tk.Label(self.interpolation_frame, text="Tipo de Interpolación:")
        self.interpolation_label.pack(side=tk.LEFT, padx=5)
        self.interpolation_options = tk.StringVar(master)
        self.interpolation_options.set("lineal")  # valor por defecto
        self.interpolation_dropdown = tk.OptionMenu(self.interpolation_frame, self.interpolation_options, "lineal", "pchip", "cubica", "slinear")
        self.interpolation_dropdown.pack(side=tk.LEFT, padx=5)

        # Botón para aplicar interpolación y actualizar la tabla
        self.btn_interpolate = tk.Button(self.interpolation_frame, text="Interpolar", command=self.interpolar_tabla, bg="blue", fg="white", font=("Arial", 10))
        self.btn_interpolate.pack(side=tk.LEFT, padx=5)

    def cargar_archivo(self):
        try:
            archivo = filedialog.askopenfilename(filetypes=[("Archivos CSV", "*.csv"), ("Archivos Excel", "*.xlsx")])
            if archivo:
                if archivo.endswith('.csv'):
                    self.df = pd.read_csv(archivo, encoding='latin-1')
                else:
                    self.df = pd.read_excel(archivo)
                
                self.mostrar_tabla()
                messagebox.showinfo("Éxito", "Archivo cargado correctamente.", icon="info")
        except Exception as e:
            messagebox.showerror("Error", f"Error al cargar el archivo: {str(e)}")

    def mostrar_tabla(self):
        # Limpiar frames
        for widget in self.info_frame.winfo_children():
            widget.destroy()

        # Mostrar tabla de datos en un PandasTable
        pt = Table(self.info_frame, dataframe=self.df, showtoolbar=True, showstatusbar=True)
        pt.show()

    def interpolar_tabla(self):
        try:
            metodo = self.interpolation_options.get()
            self.df.interpolate(method=metodo, inplace=True)
            self.mostrar_tabla()
            messagebox.showinfo("Éxito", "Interpolación aplicada correctamente.", icon="info")
        except Exception as e:
            messagebox.showerror("Error", f"Error al interpolar los datos: {str(e)}")

root = tk.Tk()
app = DataAnalyzerApp(root)
root.mainloop()
