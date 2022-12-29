package com.example.medicinereminderapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.medicinereminderapp.api.ApiService;
import com.example.medicinereminderapp.models.User;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RegisterActivity extends AppCompatActivity {

    private EditText editUsername, editPassword, editEmail, editFullname;
    private Button btnResgister;
    private TextView tvLogin;

    private List<User> mListUser;
    private User mUser;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        editUsername = findViewById(R.id.edit_usernamere);
        editPassword = findViewById(R.id.edit_passwordre);
        editEmail = findViewById(R.id.edit_emailre);
        editFullname = findViewById(R.id.edit_fullnamere);
        btnResgister = findViewById(R.id.btn_registerr);
        tvLogin = findViewById(R.id.tv_login);

        mListUser = new ArrayList<>();
        getAllUser();

        btnResgister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                clickRegister();
            }
        });
    }

    private void clickRegister() {
        String strUsername = editUsername.getText().toString().trim();
        String strPassword = editPassword.getText().toString().trim();
        String strEmail = editEmail.getText().toString().trim();
        String strFullname = editFullname.getText().toString().trim();

        if (mListUser == null || mListUser.isEmpty()) {
            return;
        }

        boolean isHasUser = false;

        for (User user : mListUser){
            if (strUsername.equals(user.getNameUser())) {
                isHasUser = true;
                break;
            }
        }

        if (isHasUser){
            Toast.makeText(RegisterActivity.this, "Username already register!", Toast.LENGTH_SHORT).show();

        }else{
            User user = new User();

            user.setNameUser(strUsername);
            user.setPasswordUser(strPassword);
            user.setEmailUser(strEmail);
            user.setFullNameUser(strFullname);

            ApiService.apiService.insertUser(user).enqueue(new Callback<User>() {
                @Override
                public void onResponse(Call<User> call, Response<User> response) {
                    Toast.makeText(RegisterActivity.this,"Register successfully",Toast.LENGTH_SHORT).show();
                    finish();
                }

                @Override
                public void onFailure(Call<User> call, Throwable t) {
                    Toast.makeText(RegisterActivity.this,"Register failed",Toast.LENGTH_SHORT).show();
                }
            });



            Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
            startActivity(intent);
        }
    }

    private void getAllUser(){

        ApiService.apiService.getListUser().enqueue(new Callback<List<User>>() {
            @Override
            public void onResponse(Call<List<User>> call, Response<List<User>> response) {
                mListUser = response.body();
                if (mListUser != null) {
                    Log.e("List Users", mListUser.size() + "");
                }
            }

            @Override
            public void onFailure(Call<List<User>> call, Throwable t) {
                Toast.makeText(RegisterActivity.this, "Call Api Error!", Toast.LENGTH_SHORT).show();
            }
        });

    }
}