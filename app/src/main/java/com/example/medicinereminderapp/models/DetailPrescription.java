package com.example.medicinereminderapp.models;

import java.io.Serializable;

public class DetailPrescription implements Serializable {
    private String idDetailPrescription;
    private String idPrescription;
    private String idMedicine;
    private String idUser;
    private int quantityDetailPrescription;
    private String contentDetailPrescription;
    private int hourDetailPrescription;
    private int minuteDetailPrescription;

    @Override
    public String toString() {
        return "DetailPrescription{" +
                "idDetailPrescription='" + idDetailPrescription + '\'' +
                ", idPrescription='" + idPrescription + '\'' +
                ", idMedicine='" + idMedicine + '\'' +
                ", idUser='" + idUser + '\'' +
                ", quantityDetailPrescription=" + quantityDetailPrescription +
                ", contentDetailPrescription='" + contentDetailPrescription + '\'' +
                ", hourDetailPrescription=" + hourDetailPrescription +
                ", minuteDetailPrescription=" + minuteDetailPrescription +
                '}';
    }

    public DetailPrescription(String idDetailPrescription, String idPrescription, String idMedicine, String idUser, int quantityDetailPrescription, String contentDetailPrescription, int hourDetailPrescription, int minuteDetailPrescription) {
        this.idDetailPrescription = idDetailPrescription;
        this.idPrescription = idPrescription;
        this.idMedicine = idMedicine;
        this.idUser = idUser;
        this.quantityDetailPrescription = quantityDetailPrescription;
        this.contentDetailPrescription = contentDetailPrescription;
        this.hourDetailPrescription = hourDetailPrescription;
        this.minuteDetailPrescription = minuteDetailPrescription;
    }

    public String getIdDetailPrescription() {
        return idDetailPrescription;
    }

    public void setIdDetailPrescription(String idDetailPrescription) {
        this.idDetailPrescription = idDetailPrescription;
    }

    public String getIdPrescription() {
        return idPrescription;
    }

    public void setIdPrescription(String idPrescription) {
        this.idPrescription = idPrescription;
    }

    public String getIdMedicine() {
        return idMedicine;
    }

    public void setIdMedicine(String idMedicine) {
        this.idMedicine = idMedicine;
    }

    public String getIdUser() {
        return idUser;
    }

    public void setIdUser(String idUser) {
        this.idUser = idUser;
    }

    public int getQuantityDetailPrescription() {
        return quantityDetailPrescription;
    }

    public void setQuantityDetailPrescription(int quantityDetailPrescription) {
        this.quantityDetailPrescription = quantityDetailPrescription;
    }

    public String getContentDetailPrescription() {
        return contentDetailPrescription;
    }

    public void setContentDetailPrescription(String contentDetailPrescription) {
        this.contentDetailPrescription = contentDetailPrescription;
    }

    public int getHourDetailPrescription() {
        return hourDetailPrescription;
    }

    public void setHourDetailPrescription(int hourDetailPrescription) {
        this.hourDetailPrescription = hourDetailPrescription;
    }

    public int getMinuteDetailPrescription() {
        return minuteDetailPrescription;
    }

    public void setMinuteDetailPrescription(int minuteDetailPrescription) {
        this.minuteDetailPrescription = minuteDetailPrescription;
    }
}
