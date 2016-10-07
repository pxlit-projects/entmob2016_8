package be.pxl.spring.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import be.pxl.spring.domain.User;

public interface UserRepository extends JpaRepository<User, Integer>{

}
