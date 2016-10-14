package be.pxl.spring.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.spring.domain.User;

@Repository
public interface UserRepository extends CrudRepository<User, Integer>{

}
