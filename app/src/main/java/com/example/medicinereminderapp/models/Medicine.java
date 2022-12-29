package com.example.medicinereminderapp.models;

import java.io.Serializable;

public class Medicine implements Serializable {
    private String idMedicine;
    private String nameMedicine;
    private String descriptionMedicine;
    private String imageUrlMedicine;
    private int idType;

    @Override
    public String toString() {
        return "Medicine{" +
                "idMedicine='" + idMedicine + '\'' +
                ", nameMedicine='" + nameMedicine + '\'' +
                ", descriptionMedicine='" + descriptionMedicine + '\'' +
                ", imageUrlMedicine='" + imageUrlMedicine + '\'' +
                ", idType=" + idType +
                '}';
    }

    public Medicine(String idMedicine, String nameMedicine, String descriptionMedicine, String imageUrlMedicine, int idType) {
        this.idMedicine = idMedicine;
        this.nameMedicine = nameMedicine;
        this.descriptionMedicine = descriptionMedicine;
        this.imageUrlMedicine = imageUrlMedicine;
        this.idType = idType;
    }

    public String getIdMedicine() {
        return idMedicine;
    }

    public void setIdMedicine(String idMedicine) {
        this.idMedicine = idMedicine;
    }

    public String getNameMedicine() {
        return nameMedicine;
    }

    public void setNameMedicine(String nameMedicine) {
        this.nameMedicine = nameMedicine;
    }

    public String getDescriptionMedicine() {
        return descriptionMedicine;
    }

    public void setDescriptionMedicine(String descriptionMedicine) {
        this.descriptionMedicine = descriptionMedicine;
    }

    public String getImageUrlMedicine() {
        return imageUrlMedicine;
    }

    public void setImageUrlMedicine(String imageUrlMedicine) {
        this.imageUrlMedicine = imageUrlMedicine;
    }

    public int getIdType() {
        return idType;
    }

    public void setIdType(int idType) {
        this.idType = idType;
    }
}
